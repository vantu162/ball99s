using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class MatrixLoading : MonoBehaviour
{
    public static MatrixLoading SharedInstance;

    void Awake()
    {
         SharedInstance = this;
    }
    public void loadLaiMaTrix(int type)
    {
        for (int y = 8; y >=0; y--)
        {
            for (int x = 0; x < 7; x++)
            {
                if (type == 0)
                {
                  
                    GameObject cell = Data.gridObjects[y, x];
                   

                    if (cell.CompareTag("box") && cell.activeInHierarchy == true)
                    {
                        cell.SetActive(false);
                      //  Debug.Log("yx: " + y + "_" + x + "| name: " + cell.name);
                        Text textNum = cell.GetComponentInChildren<Text>();
                        //Debug.Log("yx: " + y + "_" + x);
                        //Debug.Log("yx*: " + (y + 1) + "_" + x +" || "+ int.Parse(textNum.text));
                        Vector3 pos = cell.transform.position;
                        GameObject cellX = ObjectPools.SharedInstance.GetObjectFromPool(1);
                        if (cellX != null)
                        {
                            cellX.transform.position = pos;
                            cellX.SetActive(true);
                            getPositon(cell, cellX);
                        }
                       

                        GameObject cellNew = ObjectPools.SharedInstance.GetObjectFromPool(2);
                        if (cellNew != null)
                        {
                            GameObject g = Data.gridObjects[y + 1, x];
                            Vector3 posG = g.transform.position;
                            g.SetActive(false);

                            cellNew.transform.position = posG;
                            cellNew.SetActive(true);
                            Text textNumX = cellNew.GetComponentInChildren<Text>();
                            int num = int.Parse(textNum.text);
                            textNumX.text = num.ToString();
                            Image img = cell.gameObject.GetComponent<Image>();
                            img.sprite = ImageCell.SharedInstance.img(num);
                            Data.gridObjects[y + 1, x] = cellNew;
                        }
                    }

                    if (cell.CompareTag("star") && cell.activeInHierarchy == true)
                    {
                        Vector3 pos = cell.transform.position;
                        GameObject cellX = ObjectPools.SharedInstance.GetObjectFromPool(1);
                        if (cellX != null)
                        {
                            cellX.transform.position = pos;
                            cellX.SetActive(true);
                            getPositon(cell, cellX);
                        }

                        cell.SetActive(false);
                        GameObject cellNew = ObjectPools.SharedInstance.GetObjectFromPool(3);
                        if (cellNew != null)
                        {
                            GameObject g = Data.gridObjects[y + 1, x];
                            Vector3 posG = g.transform.position;
                            g.SetActive(false);
                            cellNew.transform.position = posG;
                            cellNew.SetActive(true);
                            Data.gridObjects[y + 1, x] = cellNew;
                        }
                    }

                    if (cell.CompareTag("point") && cell.activeInHierarchy == true)
                    {

                        Vector3 pos = cell.transform.position;
                        GameObject cellX = ObjectPools.SharedInstance.GetObjectFromPool(1);
                        if (cellX != null)
                        {
                            cellX.transform.position = pos;
                            cellX.SetActive(true);
                            getPositon(cell, cellX);
                        }

                        cell.SetActive(false);

                        GameObject cellNew = ObjectPools.SharedInstance.GetObjectFromPool(4);
                        if (cellNew != null)
                        {
                            GameObject g = Data.gridObjects[y + 1, x];
                            Vector3 posG = g.transform.position;
                            g.SetActive(false);
                            cellNew.transform.position = posG;
                            cellNew.SetActive(true);
                            Data.gridObjects[y + 1, x] = cellNew;
                        }
                    }
                }

                if (type == 1)
                {
                    GameObject gameObject = Data.gridObjects[y, x];

                    if (gameObject.CompareTag("box") && gameObject.activeInHierarchy == true ||
                        gameObject.CompareTag("point") && gameObject.activeInHierarchy == true ||
                        gameObject.CompareTag("star") && gameObject.activeInHierarchy == true)
                    {
                        //
                       
                        GameObject cell = ObjectPools.SharedInstance.GetObjectFromPool(1);
                        if (cell != null)
                        {
                            //Debug.Log("cell: " + cell.name);
                            cell.transform.position = gameObject.transform.position; 
                            cell.SetActive(true);
                            Data.gridObjects[y, x] = cell;   
                            gameObject.SetActive(false);
                    }
                        } 
                    
                }

            } 
        }       
    }

        public void getPositon(GameObject gameCollision, GameObject gameActive)
    {
        // Debug.Log("getPositon gameCollision: " + gameCollision.transform.position.y + ": " + gameCollision.transform.position.x);
        for (int y = 0; y <= 8; y++)
        {
            for (int x = 0; x < 7; x++)
            {
                GameObject cell = Data.gridObjects[y, x];
                if (gameCollision.transform.position.y == cell.transform.position.y && gameCollision.transform.position.x == cell.transform.position.x)
                {
                    Data.gridObjects[y, x] = gameActive;
                  
                }

            }
        }
    }

}
