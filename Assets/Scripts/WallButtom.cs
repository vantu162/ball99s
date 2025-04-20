using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WallButtom : MonoBehaviour
{
    public static Vector3 NextPosition;
    public static bool firstHit;

    public static WallButtom SharedInstance;
    public bool shouldMove = false;

    public Sprite ballSprite;

    void Awake()
    {
        SharedInstance = this;
    }
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
            if (Data.Instance.statusGame == 2)
            {
                Data.Instance.checkShoot = true;

            }
            checkInitMatrixFirst = true;

            Data.Instance.statusGame = 1;
            Level.Instance.readData();

            if (checkInitMatrixFirst && Data.Instance.checkSecondBall)
            {
                //    Debug.Log("Va chạm với: " + collision.transform.tag);
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

                Rigidbody2D rb = FirstBall.GetComponent<Rigidbody2D>();
                //rb.velocity = Vector2.zero; // Dừng bóng lại
                rb.gravityScale = 0;
                posFirst = collision.contacts[0].point;

                FirstBall.transform.position = Vector3.MoveTowards(FirstBall.transform.position, posFirst, 100f);

                //rb.MovePosition(newPos);

                FirstBall.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                Physics2D.SyncTransforms();

                //FirstBall.transform.position = Vector3.MoveTowards(FirstBall.transform.position, posFirst, 100f);

                //FirstBall.transform.position = posFirst;
                Data.Instance.boolFisrtBall = false;


            }

            collision.transform.GetComponent<CircleCollider2D>().enabled = false;
            collision.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            collision.transform.GetComponent<BallMoveto>().Move = true;

            //collision.gameObject.SetActive(false);


            if (Data.Instance.countBulletHide == Data.Instance.tatolBullet)
            {
                TextController.Instance.totalBall = Data.Instance.tatolBullet;
                Matrix.initBox(0);
                Data.Instance.checkShoot = true;
                Data.Instance.countBulletHide = 0;

                FirstBall.GetComponent<Image>().enabled = true;
            
                //FirstBall.transform.gameObject.SetActive(true);
            }

        }

    }


}
