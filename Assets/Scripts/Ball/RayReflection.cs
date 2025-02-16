using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

namespace rayCast
{
    public class RayReflection : MonoBehaviour
    {
        public Transform laserSpawner;
        public LayerMask _layerMask;
        public LineRenderer line;
        //[SerializeField] Vector2 minMaxAngle;
        private Rigidbody2D rb2d;
        public float maxRaycastDistance = 10f; // Độ dài tối đa của tia ray

        [SerializeField] GameObject turret;

        void Start()
        {
           
            rb2d = GetComponent<Rigidbody2D>(); 
            rb2d.gravityScale = 0;
            if (gameObject.GetComponent<LineRenderer>() != null)
            {
                line = gameObject.GetComponent<LineRenderer>();
            }
            //for (int i = 0; i < line.positionCount; i++)
            //{
            //    line.SetPosition(i, new Vector3(laserSpawner.position.x, laserSpawner.position.y, 0));
            //}
        }

        void FixedUpdate()
        {

            //rb2d.velocity = new Vector2(10f, rb2d.velocity.y);
            var status = EnumScript.gameStatus.play;

            if ((int)status == Data.Instance.statusGame)
            {

                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

                if (hit.collider != null)
                {
                    // Kiểm tra nếu GameObject có tag là "menu"
                    if (hit.collider.CompareTag("menu"))
                    {
                        return; // Không chạy sự kiện Input.GetMouseButtonUp(0)
                    }

                }


                if (Input.GetMouseButton(0))
                {
                    line.enabled = true;                 
                    Vector2 v2 = new Vector3((Camera.main.ScreenToWorldPoint(Input.mousePosition) - 1 * laserSpawner.position).x, (Camera.main.ScreenToWorldPoint(Input.mousePosition) - 1 * laserSpawner.position).y, 0);              
                   DrawLine(laserSpawner.position, v2, 1);
                }
                else
                {
                    for (int i = 0; i < line.positionCount; i++)
                    {
                        line.SetPosition(i, new Vector3(laserSpawner.position.x, laserSpawner.position.y, 0));
                    }
                    line.enabled = false;
                }
            }



        }

        private Vector2 direction;
        private float angle;

        [SerializeField] Vector2 angleMinMax;
  
        void DrawLine(Vector2 initRayPos, Vector2 lastRayPos, int linePosIndex)
        {
     
            if (linePosIndex < line.positionCount)
            {
                RaycastHit2D hit = Physics2D.Raycast(initRayPos, lastRayPos - initRayPos, Vector3.Distance(lastRayPos, initRayPos), _layerMask);
                Vector2 endPoint = lastRayPos;
                Vector3 dir = endPoint - initRayPos; // Hướng của đường line
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg -90f; // Tính góc xoay

              //  Debug.Log("Tính toán góc: " + angle);

                turret.transform.rotation = Quaternion.Euler(0, 0, angle); // Xoay turret

                //if (angle >= angleMinMax.x && angle <= angleMinMax.y )
                //{
                    //Data.Instance.checkShoot = true; 
                    if (hit.collider != null)
                        {
                            endPoint = hit.point;
                            float remDist = Vector3.Distance(lastRayPos, initRayPos) - hit.distance;
                            Vector2 refVect = remDist * Vector2.Reflect((hit.point - initRayPos), hit.normal).normalized;
                            DrawLine(hit.point + new Vector2(refVect.x * 0.01f, refVect.y * 0.01f), refVect + hit.point, linePosIndex + 1);
                            Debug.DrawLine(hit.point, hit.point + refVect.normalized * .2f, Color.blue);
                            // Khoi tao dot 
                           DottedLine.DottedLine.Instance.DrawDottedLine(hit.point, hit.point + refVect.normalized * .2f);
                        }

                        direction = (endPoint - initRayPos).normalized;
                        Vector2 step = direction * 0.25f;
                        // Tính vị trí mới
                        Vector2 newPosition = initRayPos + step;
                        // Khoi tao dot 
                        DottedLine.DottedLine.Instance.DrawDottedLine(newPosition, endPoint);
                        Debug.DrawRay(initRayPos, lastRayPos - initRayPos);
                //}
                //else
                //{
                //    Data.Instance.checkShoot = false;
                //}

            }

        }

        public GameObject ballPrefab;
        public GameObject canvas;
        public GameObject gameObjectFirst;

        public void Update()
        {


            //if (EventSystem.current.IsPointerOverGameObject())
            //{
            //    return; // Nếu nhấn vào UI hoặc GameObject, bỏ qua Input
            //}



            var status = EnumScript.gameStatus.play;

            if ((int)status == Data.Instance.statusGame)
            {
                
                if (!Data.Instance.checBtn && Input.GetMouseButtonUp(0))
                {
                    if (Data.Instance.checkShoot == true )
                    {
                        StartCoroutine(ShootBalls());
                    }
                }
            }
        }

        public IEnumerator ShootBalls()
        {
           // Debug.Log("Data.tatolBullet: " + Data.Instance.tatolBullet);
            Data.Instance.checkShoot = false;
            for (int i = 0; i < Data.Instance.tatolBullet; i++)
            {
                yield return new WaitForSeconds(0.15f);
                GameObject ball = ObjectPools.SharedInstance.GetObjectFromPool(5);
                TextController.Instance.totalBall -= 1;

                if (ball != null)
                {
                    if (i == 0)
                    {

                        Data.Instance.boolFisrtBall = true;
                    }
                    ball.transform.position = turret.transform.position;
                    ball.SetActive(true);
                    ball.transform.SetParent(canvas.transform, true);

                    // ball.GetComponent<Rigidbody2D>().AddForce(direction * 500f); // Sử dụng hướng tính được từ đường line

                    Vector2 force = direction * 375f;
                    ball.GetComponent<Rigidbody2D>().AddForce(force);
                }

            }
            gameObjectFirst.SetActive(false);
        }

    }
}