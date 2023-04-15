using UnityEngine;
using UnityEngine.UI;


public class MoveButtons : MonoBehaviour
{
    [SerializeField] private Text sizeText;
    [SerializeField] private Slider sizeSlider;
    [SerializeField] private ControlElement[] elements;


    private ControlElement whatElem;

    private void Start()
    {
        whatElem = null;

        sizeSlider.enabled = false;

        foreach(var item in elements)
        {
            item.element.GetComponent<RectTransform>().anchoredPosition = item.Position;
            item.element.GetComponent<RectTransform>().sizeDelta = item.Size;
        }
    }

    private void Update()
    {
        foreach(var elem in elements)
        {
            if (elem.IsActive)
            {
                sizeSlider.enabled = true;
                whatElem = elem;

                sizeSlider.value = 1.5f - whatElem.Size.x / whatElem.defSize.x;
            }
        }

        if (whatElem != null)
        {
            sizeText.text = ((sizeSlider.value + 0.5f) * 100).ToString("F0") + "%";
        }
        else
        {
            sizeText.text = 100.ToString("F0") + "%";
            sizeSlider.value = 0.5f;
        }
    }

    public void ResetElements()
    {
        foreach(var item in elements)
        {
            item.element.GetComponent<RectTransform>().anchoredPosition = item.defPos;
            item.element.GetComponent<RectTransform>().sizeDelta = item.defSize;
        }

        SaveElements();
    }

    public void SaveElements()
    {
        foreach (var item in elements)
        {
            item.Size = item.element.GetComponent<RectTransform>().sizeDelta;
            item.Position = item.element.GetComponent<RectTransform>().anchoredPosition;
        }
    }

    public void SetSize(float value)
    {
        if (whatElem != null)
        {
            whatElem.element.GetComponent<RectTransform>().sizeDelta = whatElem.defSize / (1 - value + 0.5f);
        }
    }
}
