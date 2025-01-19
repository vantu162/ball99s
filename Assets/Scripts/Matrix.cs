using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Matrix : MonoBehaviour
{

    public static int yy = 10; // num row of matrix
    public static int xx = 7; // num col of matrix
   
    public static GameObject matrixParent;
    [SerializeField]
    GameObject broudMatrix;
    public static Matrix SharedInstance;

    //public GameObject ballFirst;
    void Start()
    {  
        matrixParent = broudMatrix;

        Data.gridObjects = new GameObject[yy, xx];
        BoxCollider2D parentCollider = matrixParent.GetComponent<BoxCollider2D>();

        if (parentCollider == null)
        {
            Debug.LogError("GameObjectParent must have a BoxCollider2D component.");
            return;
        }

        Vector2 parentSize = parentCollider.size;
        float cellWidth = parentSize.x / xx;
        float cellHeight = parentSize.y / yy;

        for (int row = 0; row < yy; row++)
        {
            for (int col = 0; col < xx; col++)
            {
                // Tính toán vị trí spawn sao cho nó nằm trong BoxCollider2D của gameObjectParent
                float spawnX = (col + 0.5f) * cellWidth - parentSize.x / 2f;
                float spawnY = -((row + 0.5f) * cellHeight - parentSize.y / 2f);
                Vector2 spawnPos = new Vector2(spawnX, spawnY);
                GameObject newObject = ObjectPools.SharedInstance.GetObjectFromPool(1);

                if (newObject != null)
                {
                    newObject.transform.position = spawnPos;
                    Data.gridObjects[row, col] = newObject;
                    newObject.transform.SetParent(matrixParent.transform, false);
                }
            }
        }
        //173.91 , -1.82
        matrixParent.transform.rotation = Quaternion.Euler(-1.82f, 1.77f, 0f);
    }


    public static void Reset()
    {   
        for (int row = 0; row < yy; row++)
        {
            for (int col = 0; col < xx; col++)
            {
                GameObject gameObject = Data.gridObjects[row, col];
                Vector3 cellPos = gameObject.transform.position;

                if (gameObject != null && gameObject.activeSelf)
                {
                    gameObject.SetActive(false);
                    GameObject cell = ObjectPools.SharedInstance.GetObjectFromPool(1);
                    if (cell != null)
                    {
                        cell.transform.position = cellPos;
                        cell.SetActive(true);
                        Data.gridObjects[row, col] = cell;
                    }
                }
            }
        }
    }

  public static void initBox(int rowCurrent)
    {

        MatrixLoading.SharedInstance.loadLaiMaTrix();
        Data.Instance.upDateRowNext(rowCurrent);
        for (int x = 0; x < xx; x++)
        {
            khoiTaoDoiTuong(0, x, matrixParent);

            GameObject cell = Data.gridObjects[9, x];
            if (cell.CompareTag("box") && cell.activeInHierarchy == true || cell.CompareTag("point") && cell.activeInHierarchy == true || cell.CompareTag("star") && cell.activeInHierarchy == true)
            {
                GameController.SharedInstance.gameEnd();
            }
        }

    }


    private static void khoiTaoDoiTuong(int y, int x, GameObject Parent)
    {
        System.Random random = new System.Random();

        int randomProbability = random.Next(0, 7);
        int[] arr = arrX(randomProbability);

        GameObject gameObject = Data.gridObjects[y, x];
        if (gameObject.CompareTag("cell") && gameObject.activeInHierarchy)
        {
            Vector3 spawnPosition = gameObject.transform.position;
            if (gameObject != null)
            {
                for (int i = 0; i < arr.Length; i++)
                {

                    if (x == arr[i] && arr[i] == random.Next(1, 15))
                    {
                      
                        gameObject.SetActive(false);
                        gameObject = ObjectPools.SharedInstance.GetObjectFromPool(3);
                      

                    }
                    else if (x == arr[i] && arr[i] == random.Next(1, 15))
                    {
                        gameObject.SetActive(false);
                        gameObject = ObjectPools.SharedInstance.GetObjectFromPool(4);

                    }
                    else if (x == arr[i])
                    {
                        gameObject.SetActive(false);
                        gameObject = ObjectPools.SharedInstance.GetObjectFromPool(2);// Instantiate(tilePrefab, spawnPosition, Quaternion.identity);
                        Text textComponent = gameObject.GetComponentInChildren<Text>();

                        int number = randomV();
                        textComponent.text = number.ToString();

                        Image img = gameObject.GetComponent<Image>();
                        img.sprite = ImageCell.SharedInstance.img(number);
                    }
                   // gameObject.transform.localScale = new Vector3(1, 1, 1);
                    gameObject.transform.position = spawnPosition;
                    Data.gridObjects[y, x] = gameObject;
                    gameObject.transform.SetParent(Parent.transform, true);
                }
            }
        }
    }


    private static int randomV()
    {
        System.Random random = new System.Random();
        var v = TextController.Instance.totalBox;
        int number = 0;
     
        if (v > 1 && v >= Data.Instance.index)
        {
            Data.Instance.index += 10;
            Data.Instance.b += 2;
        }

        number = random.Next(Data.Instance.a, Data.Instance.b);
        return number;
    }

    private static int randomStar(int maxValue)
    {
        System.Random random = new System.Random();
        int value = random.Next(0, maxValue);
       // Debug.Log("randomStar ===> " + value);
        return value;
    }

    private static int[] arrX(int choose)
    {
        int[] arr = null;
        switch (choose)
        {
            case 0:
                arr = GenerateRandomArray(1);
                //  Debug.Log("0");
                break;
            case 1:
                arr = GenerateRandomArray(2);
                //  Debug.Log("1");
                break;
            case 2:
                arr = GenerateRandomArray(3);
                //  Debug.Log("2");
                break;
            case 3:
                arr = GenerateRandomArray(4);
                //  Debug.Log("3");
                break;
            case 4:
                arr = GenerateRandomArray(5);
                // Debug.Log("4");
                break;
            case 5:
                arr = GenerateRandomArray(6);
                // Debug.Log("5");
                break;
            case 6:
                arr = GenerateRandomArray(7);
                //  Debug.Log("6");
                break;
        }
        return arr;
    }

    public static int[] GenerateRandomArray(int size)
    {
        System.Random random = new System.Random();
        int[] newArray = new int[size];
        HashSet<int> set = new HashSet<int>();

        for (int i = 0; i < size; i++)
        {
            int val = random.Next(0, 7);

            // Kiểm tra nếu giá trị đã tồn tại trong HashSet
            while (set.Contains(val))
            {
                val = random.Next(0, 7); // Sinh ra giá trị mới nếu trùng lặp
            }

            newArray[i] = val;
            set.Add(val); // Thêm giá trị vào HashSet để kiểm tra trùng lặp trong lần lặp tiếp theo
        }

        //Debug.Log("newArray ========> " + ArrayToString(newArray));
        return newArray;
    }


}
