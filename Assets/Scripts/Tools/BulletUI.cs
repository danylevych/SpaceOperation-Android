using UnityEngine;
using UnityEngine.UI;

public class BulletUI: MonoBehaviour
{
    public static BulletUI instance;

    [SerializeField] private Text countText;
    [SerializeField] private Animator bulletImgreload;


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        countText.text = Tools.BulletLimit.MaxBulletVolley.ToString("0");
        bulletImgreload.Play("NormalBulletImg");
    }

    private void Update()
    {
        countText.text = (Tools.BulletLimit.MaxBulletVolley - Tools.BulletLimit.CountBullet).ToString("0");
    }

    public void Reload()
    {
        bulletImgreload.Play("BulletImgReload");
    }

    public void Normal()
    {
        bulletImgreload.Play("NormalBulletImg");
    }
}
