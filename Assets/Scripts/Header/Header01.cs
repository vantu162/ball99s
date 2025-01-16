using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Header01 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject itemLeft;
    public GameObject itemRight;

    // Update is called once per frame
    void Update()
    {
        if (TextController.Instance != null)
        {
            getItemLeft();
            getItemRight();
        }
        else
        {
            Debug.LogError("TextController.Instance is null.");
        }
    }


    void getItemLeft()
    {
        var v = TextController.Instance.point;

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



    void getItemRight()
    {
        var v = TextController.Instance.star;

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
