
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
            Data.Instance.tatolBullet = data.bullet;
        }
        else
        {
            Debug.LogError("Không thể tìm thấy tệp JSON tại đường dẫn: " + path);
        }
    }

    public void saveData(int v, int v2, int v3)
    {
        var data = new { bullet = 1 , point = v,  star = v3 };

        // Convert the object to JSON
        string jsonData = JsonConvert.SerializeObject(data, Formatting.Indented);

        // Specify the file path
        string filePath = Application.dataPath + "/Resources/data.json";

        // Write the JSON to a file
        File.WriteAllText(filePath, jsonData);

        Debug.Log($"Data saved to {filePath}");

    }
   
}
