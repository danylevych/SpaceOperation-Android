using UnityEngine;


// +=========================================+
// |                                         |
// |  This script consist of the information |
// |      about the current user ship.       |
// |                                         |
// +=========================================+

public class UserShip : MonoBehaviour
{
    public static UserShip instance;

    [SerializeField] private ShipManager manager;  // Consist of all info about all ships.
    [SerializeField] private Transform leftWeapon;
    [SerializeField] private Transform rightWeapon;

    private int voley;
    public int VoleyCount {
        get
        {
            return voley;
        }
    }

    private float reloadTime;
    public float ReloadTime {
        get
        {
            return reloadTime;
        }
    }

    private void Awake()
    {
        int userChoese = PlayerPrefs.GetInt("userShip", 0);  // Set the type of ship.

        voley = manager.GetShip(userChoese).voley;  // Set the voley for a ship.
        reloadTime = manager.GetShip(userChoese).reloadingTime;  // Set reloading time for a ship.

        gameObject.tag = manager.GetShip(userChoese).name;  // Set tag for the ship gameObject.

        gameObject.GetComponent<SpriteRenderer>().sprite = manager.GetShip(userChoese).shipSprite;  // Set the ship sprite.
        gameObject.GetComponentInChildren<Weapon>().bulletPref = manager.GetShip(userChoese).bulletPref;  // Set the bullet pref for a ship. 
        gameObject.GetComponentInChildren<Weapon>().shootingAudio.clip = manager.GetShip(userChoese).shootingAudio;  // Set the shooting sound.

        // Set the position of the weapons on a ship.
        leftWeapon.localPosition = manager.GetShip(userChoese).leftWeapon;
        rightWeapon.localPosition = manager.GetShip(userChoese).rightWeapon;

        if(instance == null)
        {
            instance = this;
        }
    }
}