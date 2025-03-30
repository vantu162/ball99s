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
        on.SetActive(false);
        off.SetActive(true);
        Debug.Log("Turn On");
    }
    public void turnOff()
    {
        on.SetActive(true);
        off.SetActive(false);
        step = speed * Time.deltaTime;


        handle.transform.position = Vector3.MoveTowards(handle.transform.position, off.transform.position, 110f);
        Debug.Log("TurnOff");
    }

}
