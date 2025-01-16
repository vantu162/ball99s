using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageCell: MonoBehaviour
{
    public Sprite[] imgs;
    public static ImageCell SharedInstance;

    void Awake()
    {
        SharedInstance = this;
    }
    public Sprite img(int num)
    {
        for (int i = 0; i < imgs.Length; i++)
        {

            if (num <= 3)
            {
                if (i == 0)
                {
                    return imgs[i];
                }
            }
            else
            {
                if (i == 1)
                {
                    return imgs[i];
                }
      
            }

        }
        return null;
    }


}
