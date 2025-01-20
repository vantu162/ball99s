using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextController: MonoBehaviour
{
    public static TextController Instance;

    public int totalGold;
    public int totalBox;
    public int totalStar;
    public int totalBall;

    public int point;
    public int star;
    public int bullet;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    // Phương thức cập nhật totalOne
    public void UpdateTotalGold(int a)
    {
        totalGold = a;
    }

    // Phương thức cập nhật totalBall
    public void UpdateTotalBox(int a)
    {
        totalBox = a;
    }

    public void UpdateTotalStar(int a)
    {
        totalStar = a;
    }



    public void UpdatePoint(int a)
    {
        point = a;
    }

    public void UpdateStar(int a)
    {
        star = a;
    }


}
