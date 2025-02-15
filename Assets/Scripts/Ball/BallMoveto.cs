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
        Vector2 currentCollisionPoint = collision.contacts[0].point;

        //Debug.Log("name =========> " + collision.gameObject.name);

        if (collision.gameObject.name == "Top")
        {
            HandleRepeatedCollision(ref collisionCountT, ref lastCollisionPointT, currentCollisionPoint,randomAngle(10,45), 0);
        }
        else if (collision.gameObject.name == "Left")
        {
            HandleRepeatedCollision(ref collisionCountL, ref lastCollisionPointL, currentCollisionPoint,randomAngle(45, 90), 1);
        }
        else if (collision.gameObject.name == "Right")
        {
            HandleRepeatedCollision(ref collisionCountR, ref lastCollisionPointR, currentCollisionPoint,randomAngle(-90, -45), 2);
        }
        else if (collision.gameObject.name == "box")
        {
            HandleRepeatedCollision(ref collisionCountBox, ref lastCollisionPointBox, currentCollisionPoint, randomAngle(10,145), 2);
        }
    }

    private void HandleRepeatedCollision(ref int collisionCount, ref Vector2 lastCollisionPoint, Vector2 currentCollisionPoint, float defaultAngle, int resetIndex)
    {
        if (Vector2.Distance(currentCollisionPoint, lastCollisionPoint) < 0.05f)
        {
            collisionCount++;
        }
        else
        {
            collisionCount = 1;
            lastCollisionPoint = currentCollisionPoint;
        }

        if (collisionCount > 2) // Nếu va chạm nhiều lần tại cùng vị trí
        {
            float newAngle = defaultAngle + randomAngle(10,20); // Thêm một độ lệch ngẫu nhiên
            ChangeDirection(newAngle, resetIndex);
        }
    }

    private int randomAngle(int minValue, int maxValue)
    {
        System.Random random = new System.Random();
        return random.Next(minValue, maxValue); // Tránh giá trị quá nhỏ
    }

    private void ChangeDirection(float angleInDegrees, int resetIndex)
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            float speed = rb.velocity.magnitude;
            float currentAngle = Mathf.Atan2(rb.velocity.y, rb.velocity.x) * Mathf.Rad2Deg;
            float newAngle = currentAngle + angleInDegrees;

            Vector2 newVelocity = new Vector2(Mathf.Cos(newAngle * Mathf.Deg2Rad), Mathf.Sin(newAngle * Mathf.Deg2Rad)) * speed;
            rb.velocity = newVelocity;
        }

        ResetCollisionState(resetIndex);
    }
    private void ResetCollisionState(int v)
    {
        if (v == 0)
        {
            collisionCountT = 0;
            lastCollisionPointT = Vector2.zero;
        }
        else if (v == 1)
        {
            collisionCountL = 0;
            lastCollisionPointL = Vector2.zero;
        }
        else if (v == 2)
        {
            collisionCountR = 0;
            lastCollisionPointR = Vector2.zero;
        }
    }
}
