using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMoveto : MonoBehaviour
{
    public bool Move;
    private float speed = 30f;
    private float step;
    public static bool firstHit;

    private void Start()
    {
        Move = false;
    }
    private void FixedUpdate()
    {
        

        if (Move == true)
        {
           step = speed * Time.deltaTime;

            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, WallButtom.posFirst, step);
            if (Vector2.Distance(gameObject.transform.position, WallButtom.posFirst) < 0.0001f)
            {
                this.gameObject.SetActive(false);

                this.transform.GetComponent<CircleCollider2D>().enabled = true;
                this.transform.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                this.transform.GetComponent<BallMoveto>().Move = false;
            }
        }
    }
    private void OnDestroy()
    {
        if (firstHit == false)
        {
            firstHit = true;
        }
    }
    private int collisionCountT = 0;
    private int collisionCountL = 0; // Biến đếm số lần va chạm tại cùng vị trí
    private int collisionCountR = 0;
    private int collisionCountBox = 0;
    private Vector2 lastCollisionPointT, lastCollisionPointL, lastCollisionPointR, lastCollisionPointBox; // Vị trí va chạm cuối cùng

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.name == "Top")
        {
            Vector2 currentCollisionPoint = collision.contacts[0].point;

            // Kiểm tra nếu khoảng cách giữa vị trí va chạm hiện tại và cuối cùng là nhỏ
            if (Vector2.Distance(currentCollisionPoint, lastCollisionPointT) < 0.01f)
            {
                collisionCountT++; // Tăng biến đếm
            }
            else
            {
                // Đặt lại biến đếm và cập nhật vị trí va chạm cuối cùng
                collisionCountT = 1;
                lastCollisionPointT = currentCollisionPoint;
            }

            if (collisionCountT > 2)
            {
                // Đổi hướng của gameObject
                ChangeDirection(45f, 0);
            }
        }

        if (collision.gameObject.name == "Left")
        {
            Vector2 currentCollisionPoint = collision.contacts[0].point;

            // Kiểm tra nếu khoảng cách giữa vị trí va chạm hiện tại và cuối cùng là nhỏ
            if (Vector2.Distance(currentCollisionPoint, lastCollisionPointL) < 0.01f)
            {
                collisionCountL++; // Tăng biến đếm
            }
            else
            {
                // Đặt lại biến đếm và cập nhật vị trí va chạm cuối cùng
                collisionCountL = 1;
                lastCollisionPointL = currentCollisionPoint;
            }

            if (collisionCountL > 2)
            {
                // Đổi hướng của gameObject
                ChangeDirection(135f,1);
            }
        }

        if (collision.gameObject.name == "Right")
        {
            Vector2 currentCollisionPoint = collision.contacts[0].point;

            // Kiểm tra nếu khoảng cách giữa vị trí va chạm hiện tại và cuối cùng là nhỏ
            if (Vector2.Distance(currentCollisionPoint, lastCollisionPointR) < 0.01f)
            {
                collisionCountR++; // Tăng biến đếm
            }
            else
            {
                // Đặt lại biến đếm và cập nhật vị trí va chạm cuối cùng
                collisionCountR = 1;
                lastCollisionPointR = currentCollisionPoint;
            }

            if (collisionCountR > 2)
            {

                ChangeDirection(-135f,2);
            }
        }


        if (collision.gameObject.name == "box")
        {
            Vector2 currentCollisionPoint = collision.contacts[0].point;

            // Kiểm tra nếu khoảng cách giữa vị trí va chạm hiện tại và cuối cùng là nhỏ
            if (Vector2.Distance(currentCollisionPoint, lastCollisionPointBox) < 0.01f)
            {
                collisionCountBox++; // Tăng biến đếm
            }
            else
            {
                // Đặt lại biến đếm và cập nhật vị trí va chạm cuối cùng
                collisionCountBox = 1;
                lastCollisionPointBox = currentCollisionPoint;
            }

            if (collisionCountBox > 2)
            {
                // Đổi hướng của gameObject

                var x = randomAngle(90);
                ChangeDirection(x, 2);
            }
        }


    }

    private  int randomAngle(int maxValue)
    {
        System.Random random = new System.Random();
        int value = random.Next(45, maxValue);
        return value;
    }
    private void ChangeDirection(float angleInDegrees, int v)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            // Lấy góc hiện tại của vận tốc
            float currentAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;

            // Đổi hướng vận tốc với góc mới
            float newAngle = currentAngle + angleInDegrees;
            Vector2 newVelocity = Quaternion.AngleAxis(newAngle, Vector3.forward) * rb.velocity;
            rb.velocity = newVelocity;
        }

        if (v == 0)
        { 
            collisionCountT = 0;
            lastCollisionPointT = Vector2.zero;
        }
        else if(v == 1)
        { 
            collisionCountL = 0;
           lastCollisionPointL = Vector2.zero;
        }else if(v == 2)
        {
            collisionCountR = 0;
            lastCollisionPointR = Vector2.zero;
        }
        // Đặt lại biến đếm và vị trí va chạm cuối cùng    
    }

}
