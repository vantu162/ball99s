using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MatrixLevel: MonoBehaviour
{

    public static int row = 4; // num row of matrix
    public static int col = 5; // num col of matrix

    public static GameObject matrixParent;
    [SerializeField]
    GameObject broudMatrix;
    public GameObject prefab;
    // public static MatrixLevel SharedInstance;

    void Start()
    {
        matrixParent = broudMatrix;
        Data.Instance.gridLevel = new GameObject[row, col];
        getMatrix();

    }

    public static void getMatrix()
    {
        BoxCollider2D parentCollider = matrixParent.GetComponent<BoxCollider2D>();

        if (parentCollider == null)
        {
            Debug.LogError("GameObjectParent must have a BoxCollider2D component.");
            return;
        }

        Data.Instance.page = 0;

        Vector2 parentSize = parentCollider.size;
        float cellWidth = parentSize.x / col;
        float cellHeight = parentSize.y / row;

        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {
                // Tính toán vị trí spawn sao cho nó nằm trong BoxCollider2D của gameObjectParent
                float spawnX = (x + 0.5f) * cellWidth - parentSize.x / 2f;
                float spawnY = -((y + 0.5f) * cellHeight - parentSize.y / 2f);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject newObject = ObjectPools.SharedInstance.GetObjectFromPool(6);
                //GameObject newObject = Instantiate(prefab, transform.position, Quaternion.identity);

                if (newObject != null)
                {
                 
                    newObject.transform.position = spawnPos;
                    Data.Instance.gridLevel[y, x] = newObject;

                    Text textComponent = newObject.GetComponentInChildren<Text>();

                    int number = 0;
                    number = (y * col) + x + 1;
                    textComponent.text = number.ToString();

                    newObject.transform.SetParent(matrixParent.transform, false);
                }
            }
        }
        matrixParent.transform.rotation = Quaternion.Euler(-1.82f, 1.77f, 0f);
    }

    public static void getInit(int k)
    {
        for (int y = 0; y < row; y++)
        {
            for (int x = 0; x < col; x++)
            {

                GameObject gameObject = Data.Instance.gridLevel[y, x];
                Vector3 cellPos = gameObject.transform.position;

                int number = 0;
                if (k == 0)
                {
                    number = (y * col) + x + 1;
                }
                else if (k == 1)
                {
                    number = 20 + (y * col) + x + 1;
                }
                else if (k == 2)
                {
                    number = 40 + (y * col) + x + 1;
                }
                else if (k == 3)
                {
                    number = 60 + (y * col) + x + 1;
                }
                else if (k == 4)
                {
                    number = 80 + (y * col) + x + 1;
                }
              

                if (gameObject != null && gameObject.activeSelf)
                {
         
                    Text textComponent = gameObject.GetComponentInChildren<Text>();
                    textComponent.text = number.ToString();
                    Debug.Log("Nhay vao xxx: " + textComponent.text);

                }


            
            }
        }

    }

  
}
