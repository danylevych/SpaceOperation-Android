using UnityEngine;
using UnityEngine.EventSystems;

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