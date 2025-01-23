using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public static Menu Instance;

    public GameObject gameObjec_menu;
    public GameObject gameObjec_Header01;
    void Awake()
    {
        Instance = this;
    }

    public void openMenu()
    {
        gameObjec_Header01.SetActive(false);
        gameObjec_menu.SetActive(true);

    }


    public void closeMenu()
    {
     
        gameObjec_menu.SetActive(false);

    }

    public void buyBulletByGold()
    {

        Level.Instance.buy(0);
    }

    public void buyBulletByStar()
    {

        Level.Instance.buy(1);
    }
}
