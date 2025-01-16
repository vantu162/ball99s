using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerLevel : MonoBehaviour
{


    //private Vector2 startTouchPosition, endTouchPosition;
    //private float minSwipeDistance = 50f;

    //void Update()
    //{
    //    if (Input.touchCount > 0)
    //    {
    //        Touch touch = Input.GetTouch(0);

    //        switch (touch.phase)
    //        {
    //            // Ghi nhận vị trí bắt đầu khi chạm vào màn hình
    //            case TouchPhase.Began:
    //                startTouchPosition = touch.position;
    //                break;

    //            // Ghi nhận vị trí kết thúc khi nhấc tay khỏi màn hình
    //            case TouchPhase.Ended:
    //                endTouchPosition = touch.position;
    //                DetectSwipe();
    //                break;
    //        }
    //    }
    //}

    //private void DetectSwipe()
    //{
    //    // Tính toán khoảng cách giữa vị trí bắt đầu và kết thúc
    //    float swipeDistance = Vector2.Distance(startTouchPosition, endTouchPosition);

    //    // Kiểm tra xem khoảng cách có đủ để tính là một swipe không
    //    if (swipeDistance >= minSwipeDistance)
    //    {
    //        Vector2 swipeDirection = endTouchPosition - startTouchPosition;

    //        // Xác định hướng vuốt
    //        if (Mathf.Abs(swipeDirection.x) > Mathf.Abs(swipeDirection.y))
    //        {
    //            if (swipeDirection.x > 0)
    //            {
    //                // Vuốt sang phải
    //                Debug.Log("nhay vao pr");
    //                Data.Instance.page += 1;
    //                if (Data.Instance.page > 3)
    //                {
    //                    Data.Instance.page = 4;
    //                }
    //                MatrixLevel.getInit(Data.Instance.page);
    //            }
    //            else
    //            {
    //                // Vuốt sang trái
    //                if (Data.Instance.page > 0)
    //                {
    //                    Data.Instance.page -= 1;
    //                    MatrixLevel.getInit(Data.Instance.page);
    //                }
    //                else
    //                {
    //                    MatrixLevel.getInit(0);
    //                }
    //            }
    //        }
    //    }
    //}


    private Vector2 startTouchPosition, currentTouchPosition;
    private bool isDragging = false;
    private float dragThreshold = 50f;

    void Update()
    {
        // Xử lý sự kiện trên máy tính (chuột)
        if (Input.GetMouseButtonDown(0)) // Khi nhấn chuột hoặc chạm màn hình
        {
            startTouchPosition = Input.mousePosition;
            isDragging = true;
        }

        if (Input.GetMouseButton(0) && isDragging) // Khi đang kéo
        {
            currentTouchPosition = Input.mousePosition;
            DetectDrag();
        }

        if (Input.GetMouseButtonUp(0)) // Khi thả chuột hoặc dừng chạm
        {
            isDragging = false;
        }
    }

    private void DetectDrag()
    {
        Vector2 dragDirection = currentTouchPosition - startTouchPosition;
        float dragDistance = dragDirection.magnitude;

        // Kiểm tra nếu khoảng cách kéo vượt quá ngưỡng dragThreshold
        if (dragDistance > dragThreshold)
        {
            // Xác định hướng kéo
            if (Mathf.Abs(dragDirection.x) > Mathf.Abs(dragDirection.y)) // Ưu tiên kéo ngang
            {
                if (dragDirection.x > 0)
                {
                    Debug.Log("Dragging Right");
                    Data.Instance.page += 1;
                    if (Data.Instance.page > 3)
                    {
                        Data.Instance.page = 4;
                    }
                    MatrixLevel.getInit(Data.Instance.page);
                }
                else
                {
                    Debug.Log("Dragging Left");
                    if (Data.Instance.page > 0)
                    {
                        Data.Instance.page -= 1;
                        MatrixLevel.getInit(Data.Instance.page);
                    }
                    else
                    {
                        MatrixLevel.getInit(0);
                    }

                }
                // Đặt lại vị trí bắt đầu để tiếp tục tính cho lần kéo tiếp theo
                startTouchPosition = currentTouchPosition;
            }
        }
    }



public void prLevel()
    {
      
        if (Data.Instance.page >  0)
        {
            Data.Instance.page -= 1;
            MatrixLevel.getInit(Data.Instance.page);
        }
        else
        {
            MatrixLevel.getInit(0);
        }

       
    }
    public void nextLevel()
    {

        Debug.Log("nhay vao pr");
        Data.Instance.page += 1;
        if ( Data.Instance.page > 3)
        {
            Data.Instance.page = 4;
        }
        MatrixLevel.getInit(Data.Instance.page);

    }
}
