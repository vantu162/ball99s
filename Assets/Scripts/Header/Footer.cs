using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Footer : MonoBehaviour
{
    //public GameObject itemLeft;
    public GameObject itemCenter;
    //public GameObject itemRight;



    // Update is called once per frame
    void Update()
    {
        if (Data.Instance != null)
        {
            getItemCenter();
    
        }
        else
        {
            Debug.LogError("TextController.Instance is null.");
        }
    }


    void getItemCenter()
    {
        var v = TextController.Instance.totalBall;

        if (v >= 99)
        {
            v = 99;
        }

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


}
