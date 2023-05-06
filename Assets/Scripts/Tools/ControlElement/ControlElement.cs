using UnityEngine;


// +=========================================+
// |                                         |
// |  This script consist of info about all  |
// |        user's control elements.         |
// |                                         |
// +=========================================+

[System.Serializable]
class ControlElement
{
    public string name;
    public GameObject element;
    public Vector2 defPos;
    public Vector2 defSize;


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

    public Vector2 Size
    {
        get
        {
            return new Vector2(PlayerPrefs.GetFloat(name + "SizeX", defSize.x),
                               PlayerPrefs.GetFloat(name + "SizeY", defSize.y));
        }

        set
        {
            PlayerPrefs.SetFloat(name + "SizeX", value.x);
            PlayerPrefs.SetFloat(name + "SizeY", value.y);
        }
    }

    public Vector2 Position
    {
        get
        {
            return new Vector2(PlayerPrefs.GetFloat(name + "PosX", defPos.x),
                               PlayerPrefs.GetFloat(name + "PosY", defPos.y));
        }

        set
        {
            PlayerPrefs.SetFloat(name + "PosX", value.x);
            PlayerPrefs.SetFloat(name + "PosY", value.y);
        }
    }
}
