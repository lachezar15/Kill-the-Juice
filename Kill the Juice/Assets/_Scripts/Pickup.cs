using UnityEngine;

public class Pickup : MonoBehaviour, IPickupable
{
    private PlayerInventory inventory;
    private Transform weaponHolder;

    public GameObject weapon;

    void Start()
    { 
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHandle").transform;
    }

    public void OnPickup()
    {
        Instantiate(weapon, weaponHolder);
        Destroy(this.gameObject);
    }
}
