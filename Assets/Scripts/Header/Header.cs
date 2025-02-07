using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Header : MonoBehaviour
{
   // public GameObject itemLeft;
    public GameObject itemCenter;
    public GameObject itemRight;

    // Start is called before the first frame update
    void Start()
    {
       // TextController.Instance.totalBall += 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (TextController.Instance != null)
        {
            getItemCenter();
            getItemRight();
        }
        else
        {
            Debug.LogError("TextController.Instance is null.");
        }
    }


    void getItemCenter()
    {
        var v = TextController.Instance.totalBox;

        if (itemCenter != null)
        {
            Text textNum = itemCenter.GetComponentInChildren<Text>();
            if (textNum != null)
            {
                textNum.text = v.ToString();
            }
            else
            {
                Debug.LogError("Text component not found in itemCenter's children.");
            }
        }
        else
        {
            Debug.LogError("itemCenter is not assigned.");
        }
    }

    void getItemRight()
    {
        var v = TextController.Instance.totalStar;

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
