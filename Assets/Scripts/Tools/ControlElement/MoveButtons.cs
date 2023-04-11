using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveButtons : MonoBehaviour
{
    [SerializeField] private ControlElement[] elements;


    void Start()
    {
        foreach(var item in elements)
        {
            Vector2 pos = new Vector2(PlayerPrefs.GetFloat(item.name + "PosX", item.defPos.x),
                                      PlayerPrefs.GetFloat(item.name + "PosY", item.defPos.y));

            item.element.GetComponent<RectTransform>().anchoredPosition = pos;
        }
    }

    void Update()
    {
        Transform whichElem = null;

        foreach (var item in elements)
        {
            if (item.IsActive)
            {
                whichElem = item.element.transform;
            }
        }

        if (Input.touchCount > 0)
        {
            if (whichElem != null)
            {
                whichElem.transform.position = Input.GetTouch(0).position;
            }
        }
    }


    public void ResetElements()
    {
        foreach(var item in elements)
        {
            item.element.GetComponent<RectTransform>().anchoredPosition = item.defPos;
        }

        SaveElements();
    }


    public void SaveElements()
    {
        foreach (var item in elements)
        {
            PlayerPrefs.SetFloat(item.name + "PosX", item.element.GetComponent<RectTransform>().anchoredPosition.x);
            PlayerPrefs.SetFloat(item.name + "PosY", item.element.GetComponent<RectTransform>().anchoredPosition.y);
        }
    }
}
