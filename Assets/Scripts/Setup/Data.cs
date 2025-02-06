using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data: MonoBehaviour
{

    public static Data Instance;

    public int countPos = 0;
    public int countBulletHide = 0;
    public bool checkShootStart = false;
    public bool checkShoot = true;
    public int rowY = 0;
    public static GameObject[,] gridObjects;

    public  GameObject[,] gridLevel;

    public int tatolBullet = 5;

    public ObjRange rangeBox;
    public Range rangePoint;
    public Range rangeStar;

    public int statusGame = 0;
    public bool boolFisrtBall = false;
     
    public bool checkSecondBall = true;


    public int page = 0;



    public int a = 1;
    public int b = 3;
    public int index = 50;


    public bool chekButton = false;


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

    public void upDateRowNext(int v)
    {
        rowY = v;

    }

    public void upDateTatolBullet(int v)
    {
        tatolBullet = v;
        
    }

}
