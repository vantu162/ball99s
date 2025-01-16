using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;
    public void exitsMenu()
    {

        gameOver.SetActive(false);
      //  SceneManager.LoadScene(0);
    }
    
}
