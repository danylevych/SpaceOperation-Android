using UnityEngine;
using UnityEngine.UI;


// +=========================================+
// |                                         |
// |   This script describes the weapon of   |
// |                a ship.                  |
// |                                         |
// +=========================================+

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

        // If the weapon not reloads, the time between two bullet is normal and the shoot key was pressed.
        if (Tools.Clock.CheckTime(ref timeOfEachBullet, 0.17f) && isShooting && !isReload)
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

        /*
          The isReload variable will get the value true when the reloading button will
          press, and the guns will must reload, or count using bullets will be equal
          the maximum count in one volley, what wiil be mean - user used all bullets.
        */
        if ((reloading.GetComponent<UIButton>().IsActive && Tools.BulletLimit.IsMustReloading()) ||
            (Tools.BulletLimit.CountBullet == Tools.BulletLimit.MaxBulletVolley))
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