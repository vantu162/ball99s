using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggeSound : MonoBehaviour
{

    [SerializeField] GameObject on;
    [SerializeField] GameObject off;
    [SerializeField] GameObject handle;
    private float speed = 30f;
    private float step;


    public void turnOn()
    {
        step = speed * Time.deltaTime;

        handle.transform.position = Vector3.MoveTowards(handle.transform.position, on.transform.position,  110f);
     
        handle.GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, 255); // RGB + Alpha
        //handle.GetComponent<SpriteRenderer>().color = Color.gray;

        on.SetActive(false);
        off.SetActive(true);
        AudioListener.pause = false; // Bật lại âm thanh
        Debug.Log("Turn On");
    }
    public void turnOff()
    {
        on.SetActive(true);
        off.SetActive(false);
        step = speed * Time.deltaTime;

        handle.transform.position = Vector3.MoveTowards(handle.transform.position, off.transform.position, 110f);
        handle.GetComponent<SpriteRenderer>().color = new Color32(140, 133, 133, 255); // RGB + Alpha

        AudioListener.pause = true;  // Tắt toàn bộ âm thanh
   

        Debug.Log("TurnOff");
    }

}
