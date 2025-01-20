using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameEnd : MonoBehaviour
{
    //public GameObject gameOver;

 
    public GameObject textStar;
    public GameObject textPoint;
    public GameObject textGold;

    public static GameEnd Instance;


    void Awake()
    {
       Instance = this;
    }



    public void saveTurn()
    {

        getTextPoint();
        getTextStar();
        getTextGold();


        var box = TextController.Instance.totalBox;
        var star = TextController.Instance.totalStar;
        var gold = TextController.Instance.totalGold;

        Level.Instance.saveData(0, gold, star);


    }

    public void exitsMenu()
    {
        //gameOver.SetActive(false);
      //  SceneManager.LoadScene(0);
    }

    public void getTextPoint()
    {
        var v = TextController.Instance.totalBox;

        Text textNum = textPoint.GetComponent<Text>();
        if (textNum != null)
        {
            textNum.text = v.ToString();
        }
        else
        {
            Debug.LogError("Text component not found in itemCenter's children.");
        }
    }

    public void getTextStar()
    {
        var v = TextController.Instance.totalStar;

        Text textNum = textStar.GetComponent<Text>();
        if (textNum != null)
        {
            textNum.text = v.ToString();
        }
        else
        {
            Debug.LogError("Text component not found in itemCenter's children.");
        }
    }

    public void getTextGold()
    {
        var v = TextController.Instance.totalGold;

        Text textNum = textGold.GetComponent<Text>();
        if (textNum != null)
        {
            textNum.text = v.ToString();
        }
        else
        {
            Debug.LogError("Text component not found in itemCenter's children.");
        }
    }

}
