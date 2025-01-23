
using System.IO;
using UnityEngine;
using Newtonsoft.Json;
using System.Collections.Generic;

public class Level: MonoBehaviour
{

    public static Level Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        readData();
    }

    public void readData()
    {
        string path = Application.dataPath + "/Resources/data.json";
        if (File.Exists(path))
        {
            string jsonContent = File.ReadAllText(path);
            Debug.Log("jsonContent: " + jsonContent);
            //ObjLevel obj = JsonConvert.DeserializeObject<ObjLevel>(jsonContent);
            ObjLevel data = JsonUtility.FromJson<ObjLevel>(jsonContent);

            Debug.Log("data json: " + data.bullet + "___" + data.star + "___" + data.point);
            TextController.Instance.point = data.point;
            TextController.Instance.star = data.star;
            TextController.Instance.bullet = data.bullet;


            Data.Instance.tatolBullet = data.bullet;


        }
        else
        {
            Debug.LogError("Không thể tìm thấy tệp JSON tại đường dẫn: " + path);
        }
    }

    public void saveData(int bulletV, int goldV, int starV)
    {

       var data = new { 
           bullet = updateValue(bulletV, 2), 
           point = updateValue(goldV, 0),  
           star = updateValue(starV, 1)
       };

        // Convert the object to JSON
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

        // Specify the file path
        string filePath = Application.dataPath + "/Resources/data.json";

        // Write the JSON to a file
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Data saved to {filePath}");

    }


    public void buy(int type)
    {
        int b = TextController.Instance.bullet;
        int g = TextController.Instance.point;
        int s = TextController.Instance.star;

        if (type == 0)
        {
            if (g >= 5)
            {
                g -= 5;
                b += 1;
                TextController.Instance.point = g;
                TextController.Instance.bullet = b;
            }
          
        }

        if (type == 1)
        {


            if (g >= 5)
            {
                s -= 5;
                b +=1;
                TextController.Instance.star = s;
                TextController.Instance.bullet = b;
            }
        
          
        }

        var data = new
        {
            bullet = b,
            point = g,
            star = s
        };

        // Convert the object to JSON
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

        // Specify the file path
        string filePath = Application.dataPath + "/Resources/data.json";

        // Write the JSON to a file
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Data saved to {filePath}");


       // readData();
    }



    public int updateValue(int v, int type)
    {
        int a = 0;
        switch (type)
        {
            case 0:       
 
                if (v > 0)
                {
                    a = TextController.Instance.point + v;
                }
                else
                {
                    a = TextController.Instance.point;
                }

                break;
            case 1:
                if(v > 0)
                {      
                    a = TextController.Instance.star + v;
                }
                else
                {
                    a = TextController.Instance.star;
                }

                break;
            default:
                if(v > 0)
                {
                    a = TextController.Instance.bullet + v;
                }
                else
                {
                    a = TextController.Instance.bullet;
                }
               
                break;
        }
        return a;
    }
}
