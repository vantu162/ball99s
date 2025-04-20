using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWin : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameWin SharedInstance;
    void Awake()
    {
        SharedInstance = this;
    }
    public void checkWin()
    {

        if(TextController.Instance.totalStar == 5 && TextController.Instance.totalGold == 5)
        {
          //  GameController.SharedInstance.gamePlay.SetActive(true);
        }
    }
}
