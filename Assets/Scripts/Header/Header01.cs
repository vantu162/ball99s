using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Header01 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemLeft;
    public GameObject itemRight;
    [SerializeField] GameObject itemBall;

    // Update is called once per frame
    void Update()
    {
        //if (TextController.Instance != null)
        //{
        //    getItemPoint();
        //    getItemStar();
        //}
        //else
        //{
        //    Debug.LogError("TextController.Instance is null.");
        //}
        getItemBullet();
        getItemPoint();
        getItemStar();
    }


    void getItemBullet()
    {

        var v = 0;
        v = TextController.Instance.bullet;
        Text textNum = itemBall.GetComponent<Text>();
        textNum.text = v.ToString();
    }

    void getItemPoint()
    {
        var v = 0;
        if (Data.Instance.checkTaltol == false)
        {
           v = TextController.Instance.point;

        }
        if (Data.Instance.checkTaltol == true)
        {

            v = TextController.Instance.totalBox;

        }


        if (itemLeft != null)
        {
            Text textNum = itemLeft.GetComponentInChildren<Text>();
            if (textNum != null)
            {
                textNum.text = v.ToString();
            }
            else
            {
                Debug.LogError("Text component not found in itemLeft's children.");
            }
        }
        else
        {
            Debug.LogError("itemLeft is not assigned.");
        }
    }



    void getItemStar()
    {
        var v = 0;

        if(Data.Instance.checkTaltol == false)
        {
            v = TextController.Instance.star;

        }
        if (Data.Instance.checkTaltol == true)
        {
            v = TextController.Instance.totalStar;
        }


        if (itemRight != null)
        {
            Text textNum = itemRight.GetComponentInChildren<Text>();
            if (textNum != null)
            {
                textNum.text = v.ToString();
            }
            else
            {
                Debug.LogError("Text component not found in itemRight's children.");
            }
        }
        else
        {
            Debug.LogError("itemRight is not assigned.");
        }
    }
}
