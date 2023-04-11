using UnityEngine;
using UnityEngine.UI;


public class Weapon : MonoBehaviour
{
    [SerializeField] public GameObject bulletPref;
    [SerializeField] public Transform leftFirePoit;
    [SerializeField] public Transform rightFirePoit;
    [SerializeField] public AudioSource shootingAudio;
    [SerializeField] private Button shooting;
    [SerializeField] private Button reloading;

    public float speed = 10;
    private bool isReload;
    private bool isShooting;
    private float timeOfEachBullet;

    private void Start()
    {
        isShooting = false;
        isReload = false;
        timeOfEachBullet = 0f;
    }

   
    private void Update()
    {
        ChackInput();

        if (!isReload)
        {
            BulletUI.instance.Normal();
        }

        if (!isReload && Tools.Clock.CheckTime(ref timeOfEachBullet, 0.17f) && isShooting)
        {
            Shoot();
            Tools.BulletLimit.AddCountBullet();
        }
        else if (isReload)
        {
            Reload();
        }
    }

    private void ChackInput()
    {
        isShooting = shooting.GetComponent<UIButton>().IsActive;

        if (reloading.GetComponent<UIButton>().IsActive || Tools.BulletLimit.IsReload())
        {
          isReload = true;
        }
    }

    private void Shoot()
    {
        if (bulletPref != null)
        {
            shootingAudio.Play();

            GameObject leftBullet = Instantiate(bulletPref, leftFirePoit.position, Quaternion.identity);
            GameObject rightBullet = Instantiate(bulletPref, rightFirePoit.position, Quaternion.identity);

            Destroy(leftBullet, 2f);
            Destroy(rightBullet, 2f);
        }
    }

    private void Reload()
    {
        BulletUI.instance.Reload();
        if (Tools.Clock.CheckTime(Tools.BulletLimit.TimeOneBullet))
        {
            Tools.BulletLimit.ResetCount();
        }

        if (Tools.BulletLimit.CountBullet == 0)
        {
            isReload = false;
        }
    }
}
