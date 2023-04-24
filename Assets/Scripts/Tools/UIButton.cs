using UnityEngine;
using UnityEngine.EventSystems;


// +=========================================+
// |                                         |
// |  This script can chack if buttons were  |
// |         pressed or released.            |
// |                                         |
// +=========================================+

public class UIButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool IsActive = false;
    public void OnPointerDown(PointerEventData eventData)
    {
        IsActive = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        IsActive = false;
    }
}