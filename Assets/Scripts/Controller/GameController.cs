using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
   
    public GameObject gameOver;
    public GameObject gamePlay;
    public GameObject ballFirst;

    public GameObject headerAll;

    public static GameController SharedInstance;

 
    void Awake()
    {
        SharedInstance = this;
    }

    public void startGame()
    {
       

        Data.Instance.checkSecondBall = true;
        gamePlay.SetActive(false);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Data.Instance.index = 50;
        Data.Instance.b = 3;
        headerAll.SetActive(false);
    }

    public void startGameType02()
    {

        Data.Instance.checkSecondBall = true;
        gamePlay.SetActive(false);
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        Data.Instance.index = 50;
        Data.Instance.b = 3;
        Data.Instance.b = 6;
        headerAll.SetActive(false);
    }

    public void returnHome()
    {
        Data.Instance.statusGame = 0;
        gamePlay.SetActive(true);
        ballFirst.SetActive(true);
        Data.Instance.checkSecondBall = true;
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0f;
        //Data.Instance.upDateTatolBullet(5);

        Level.Instance.readData();
        TextController.Instance.UpdateTotalStar(0);
        TextController.Instance.UpdateTotalGold(0);
        TextController.Instance.UpdateTotalBox(0);
        Data.Instance.upDateRowNext(0);
        gameOver.SetActive(false);

        Matrix.Reset();



    }

    public void pauseGame()
    {

        gameOver.SetActive(false);
      
    }

    public void Reset()
    {
        ballFirst.SetActive(true);
        Data.Instance.checkSecondBall = true;
        Rigidbody2D rb = ballFirst.GetComponent<Rigidbody2D>();
        rb.gravityScale = 0.3f;
        //Data.Instance.upDateTatolBullet(5);

        Level.Instance.readData();
        TextController.Instance.UpdateTotalStar(0);
        TextController.Instance.UpdateTotalGold(0);
        TextController.Instance.UpdateTotalBox(0);
        Data.Instance.upDateRowNext(0);
        gameOver.SetActive(false);

        Matrix.Reset();
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


