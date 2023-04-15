using UnityEngine;
using UnityEngine.EventSystems;

public class UIDrag : MonoBehaviour, IDragHandler
{
    private RectTransform tr;

    private void Start()
    {
        tr = GetComponent<RectTransform>();
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 clampedPosition = eventData.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, tr.sizeDelta.x / 2, Screen.width - tr.sizeDelta.x / 2);
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, tr.sizeDelta.y / 2, Screen.height - tr.sizeDelta.y / 2);
        tr.position = clampedPosition;
    }
}
