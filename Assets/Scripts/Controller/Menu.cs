using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        Data.Instance.checBtn = true;
        //if (Data.Instance.statusGame != 0)
        //{
        //    Data.Instance.statusGame = 0;
        //}
        Time.timeScale = 0;
        gameObjec_menu.SetActive(true);
        //  gameObjec_Header01.SetActive(false);


    }


    public void closeMenu()
    {
        //if (Data.Instance.statusGame == 0)
        //{
        //    Data.Instance.statusGame = 1;
        //}
        Time.timeScale = 1;
        gameObjec_menu.SetActive(false);

        Invoke("ResetClosing", 0.5f); // Chặn trong 0.5 giây
    }

    void ResetClosing()
    {
        Data.Instance.checBtn = false;
    }

    public void buyBulletByGold()
    {

        Level.Instance.buy(0);
    }

    public void buyBulletByStar()
    {

        Level.Instance.buy(1);
    }

    public void loadSecene()
    {

        SceneManager.LoadScene("SampleScene");
    }
}
