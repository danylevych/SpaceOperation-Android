using UnityEngine;


// +=========================================+
// |                                         |
// |   This script set the user's settings   |
// |      for buttons in game's canvas.      |
// |                                         |
// +=========================================+

public class UserButtons : MonoBehaviour
{
    [SerializeField] private ControlElement[] elements;


    private void Awake()
    {
        foreach (var item in elements)
        {
            item.element.GetComponent<RectTransform>().anchoredPosition = item.Position;
            item.element.GetComponent<RectTransform>().sizeDelta = item.Size;
        }
    }
}