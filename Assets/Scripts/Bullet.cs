using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{
    private Vector2 lastVelocity;

    void FixedUpdate()
    {
        lastVelocity = GetComponent<Rigidbody2D>().velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

      //  GetComponent<Rigidbody2D>().velocity = Vector2.Reflect(lastVelocity, collision.contacts[0].normal);
        if (collision.gameObject.tag == "box")
        {
           var x =  TextController.Instance.totalBox + 1;
            TextController.Instance.UpdateTotalBox(x);

            Text textNum = collision.gameObject.GetComponentInChildren<Text>();
            int num = int.Parse(textNum.text) - 1;


            if (num >= 1)
            {
                textNum.text = num.ToString();
                Image img = collision.gameObject.GetComponent<Image>();

                img.sprite = ImageCell.SharedInstance.img(num);
            }
            else
            {
                collision.gameObject.SetActive(false);
                Vector3 spawnPosition = collision.gameObject.transform.position;
                GameObject cell = ObjectPools.SharedInstance.GetObjectFromPool(1);
                if (cell != null)
                {
                    cell.transform.position = spawnPosition;
                    cell.SetActive(true);
                    getPositon(collision.gameObject, cell);
                }

            }

            AudioManager.Instance.PlaySFX();



        }
        else if(collision.gameObject.tag == "point")
        {
            TextController.Instance.totalGold += 1;

            collision.gameObject.SetActive(false);
            Vector3 spawnPosition = collision.gameObject.transform.position;
            GameObject cell = ObjectPools.SharedInstance.GetObjectFromPool(1);
            if (cell != null)
            {
                cell.transform.position = spawnPosition;
                cell.SetActive(true);

                var x =  Data.Instance.tatolBullet + 1;
                if(x > 99)
                {
                    x = 99;
                }
                Data.Instance.upDateTatolBullet(x);

                Data.Instance.countBulletHide += 1;
                getPositon(collision.gameObject, cell);
            }

        }
        else if(collision.gameObject.tag == "star")
        {
            TextController.Instance.totalStar += 1;

            collision.gameObject.SetActive(false);
            Vector3 spawnPosition = collision.gameObject.transform.position;
            GameObject cell = ObjectPools.SharedInstance.GetObjectFromPool(1);
            if (cell != null)
            {
                cell.transform.position = spawnPosition;
                cell.SetActive(true);
                getPositon(collision.gameObject, cell);
            }

        }

        //if (collision.gameObject.tag == "box" || collision.gameObject.tag == "point" || collision.gameObject.tag == "star")
        //{
        //    GameWin.SharedInstance.checkWin();

        //}

    }

    public void getPositon(GameObject gameCollision, GameObject gameActive)
    {
       // Debug.Log("getPositon gameCollision: " + gameCollision.transform.position.y + ": " + gameCollision.transform.position.x);
        for (int y = 0; y < 9; y++)
        {
            for(int x = 0; x < 7; x++)
            {
                GameObject cell = Data.gridObjects[y, x];
                if (gameCollision.transform.position.y == cell.transform.position.y && gameCollision.transform.position.x == cell.transform.position.x)
                {
                    Data.gridObjects[y, x] = gameActive;
                }
              
            }
        }
    }
}
