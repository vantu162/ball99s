using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   
    public GameObject gameOver;
    public GameObject gamePlay;
    public GameObject ballFirst;

    public GameObject gameOptions;

    public static GameController SharedInstance;

 
    void Awake()
    {
        SharedInstance = this;
    }

    public void startGame()
    {
        // StartCoroutine(ActivateBallAfterDelay(0.3f));

        Data.Instance.typeGame = 0;

        Data.Instance.checkTaltol = true;
        Data.Instance.checkSecondBall = true;
        gamePlay.SetActive(false);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Data.Instance.index = 50;
        Data.Instance.b = 3;
      //  headerAll.SetActive(false);
    }

    public void startGameType02()
    {
        //StartCoroutine(ActivateBallAfterDelay(0.3f));
        Data.Instance.typeGame = 1;
        Data.Instance.checkTaltol = true;

        Data.Instance.checkSecondBall = true;
        gamePlay.SetActive(false);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Data.Instance.index = 50;
        Data.Instance.b = 6;
      // headerAll.SetActive(false);
    }

    IEnumerator ActivateBallAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ballFirst.SetActive(true);
    }

    public void returnHome()
    {
        ObjectPools.SharedInstance.ActivateAllBulllet_False();
        Time.timeScale = 1;
        Data.Instance.checkTaltol = false;
        Data.Instance.checkShoot = true;

        Data.Instance.statusGame = 0;
        gamePlay.SetActive(true);
        Transform ballTransform = ballFirst.transform;
        ballTransform.position = new Vector3(0.00f, 0.40f, 90.00f);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;

        Level.Instance.readData();
        TextController.Instance.UpdateTotalStar(0);
        TextController.Instance.UpdateTotalGold(0);
        TextController.Instance.UpdateTotalBox(0);

        gameOver.SetActive(false);
        gameOptions.SetActive(false);
        ballFirst.SetActive(true);

        //MatrixLoading.SharedInstance.resetLoadLaiMaTrix();
        MatrixLoading.SharedInstance.loadLaiMaTrix(1);

        Data.Instance.checBtn = false;



    }

    public void pauseGame()
    {

        gameOver.SetActive(false);
      
    }

    public void Reset()
    {

        if (Data.Instance.typeGame == 0)
        {
            Data.Instance.index = 50;
            Data.Instance.b = 3;

        }

        if (Data.Instance.typeGame == 1)
        {
            Data.Instance.index = 50;
            Data.Instance.b = 6;

        }

        MatrixLoading.SharedInstance.loadLaiMaTrix(1);
        ballFirst.SetActive(true);
        Data.Instance.checkSecondBall = true;
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
       
        Level.Instance.readData();
        TextController.Instance.UpdateTotalStar(0);
        TextController.Instance.UpdateTotalGold(0);
        TextController.Instance.UpdateTotalBox(0);
     
        gameOver.SetActive(false);

       
    }

    public void hideGamePlay()
    {
         if (gamePlay.activeSelf)
        {
            // Ẩn GameObject
            gamePlay.SetActive(false);
            Debug.Log(gamePlay.name + " was active and is now hidden.");
        }
        else
        {
            Debug.Log(gamePlay.name + " is already hidden.");
        }

    }

    public void exitGame()
    {

        Application.Quit();

    }

    public void gameEnd()
    {

        Debug.Log("ballFirst ==================> " + ballFirst.activeSelf);
        gameOver.SetActive(true);
        Transform ballTransform = ballFirst.transform;
        ballTransform.position = new Vector3(0.00f, 0.40f, 90.00f);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        Data.Instance.checkShoot = false;

        GameEnd.Instance.saveTurn();
   
        StartCoroutine(ExecuteAfterDelay());
      
    }

    private IEnumerator ExecuteAfterDelay()
    {
        yield return new WaitForSeconds(0.3f); // Chờ 3 giây
        Debug.Log("Thực hiện câu lệnh sau 3 giây!"); // Câu lệnh cần thực hiện
        ballFirst.SetActive(false);
    }
}


