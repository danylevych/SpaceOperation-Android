using UnityEngine;


[System.Serializable]
class ControlElement
{
    public string name;
    public GameObject element;
    public Vector2 defPos;

    public bool IsActive
    {
        get
        {
            if (element.GetComponent<UIButton>() != null)
            {
                return element.GetComponent<UIButton>().IsActive;
            }
            return false;
        }
    }
}

