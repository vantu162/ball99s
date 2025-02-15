using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallButtom : MonoBehaviour
{
    public static Vector3 NextPosition;
    public static bool firstHit;
    private void Start()
    {
        firstHit = false;
        NextPosition = transform.position;
    }
    public GameObject FirstBall;
    public static bool checkInitMatrixFirst;
    public static Vector3 posFirst;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.transform.tag == "ballFirst")
        {

            checkInitMatrixFirst = true;
            //Debug.Log("checkSecondBall =====> " + Data.Instance.checkSecondBall);
            Data.Instance.statusGame = 1;
            //Data.Instance.checkShoot = true;

            if (checkInitMatrixFirst && Data.Instance.checkSecondBall)
            {
                Debug.Log("Va chạm với: " + collision.transform.tag + " vvvv: " + checkInitMatrixFirst);
                TextController.Instance.totalBall = Data.Instance.tatolBullet;
                Matrix.initBox(0);
                checkInitMatrixFirst = !checkInitMatrixFirst;
                Data.Instance.checkSecondBall = false;
            }

        }

        if (collision.transform.tag == "bullet")
        {

            TextController.Instance.totalBall += 1;

            Data.Instance.countBulletHide += 1;

            if (Data.Instance.boolFisrtBall)
            {
                posFirst = collision.gameObject.transform.position;
                FirstBall.transform.position = posFirst;
                collision.gameObject.SetActive(false);
                Data.Instance.boolFisrtBall = false;
            }
            else
            {

                collision.transform.GetComponent<CircleCollider2D>().enabled = false;
                collision.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                collision.transform.GetComponent<BallMoveto>().Move = true;
            }


            if (Data.Instance.countBulletHide == Data.Instance.tatolBullet)
            {
                TextController.Instance.totalBall = Data.Instance.tatolBullet;
                //int rowNext = Matrix.checkCellOfRowHide(Data.Instance.rowY);

                //Debug.Log("rowNext b =====> " + rowNext);

                Matrix.initBox(0);

                Data.Instance.checkShoot = true;
                Data.Instance.countBulletHide = 0;
            }

            FirstBall.transform.gameObject.SetActive(true);

        }


     
    }

}
