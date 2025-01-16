using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ClickItem : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("GameObject clicked: " + this.name);

        GameObject parentObject = this.gameObject; // Hoặc gán GameObject cha cụ thể
                                                   // Tìm thành phần Text trong các con của parentObject
        Text textComponent = parentObject.GetComponentInChildren<Text>();


        if (textComponent != null)
        {
   
            string textValue = textComponent.text;
            Debug.Log("Text Value: " + textValue);
            // Lấy Transform của cha
            Transform parentTransform = this.transform.parent.parent.parent;

            if (parentTransform != null)
            {
               parentTransform.gameObject.SetActive(false);
               GameController.SharedInstance.hideGamePlay();

            }

        }
    }
}