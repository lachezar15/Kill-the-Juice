using System;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public Transform cam;
    private Transform weaponHolder;
    [SerializeField] float pickupRange;

    public bool hasItem = false;

    private void Start()
    {
        weaponHolder = GameObject.FindGameObjectWithTag("WeaponHandle").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Pickup();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        { 
            Drop();
        }
    }

    void Pickup()
    {
        if (Physics.Raycast(cam.position, cam.forward, out RaycastHit hit, pickupRange))
        {
            if (hit.transform.TryGetComponent(out IPickupable pickup))
            {
                if (hasItem == false)
                {
                    pickup.OnPickup();
                    hasItem = true;
                }
                else
                {
                    Debug.Log("inventory full");
                }
            }
        }
    }

    public void Drop()
    {
        foreach (Transform child in weaponHolder)
        {
            GameObject objToDrop = child.GetComponent<DropWeapon>().pickup;
            Vector3 posToSpawn = cam.position + cam.forward * 1;
            Instantiate(objToDrop, posToSpawn, Quaternion.identity);
            Destroy(child.gameObject);
            hasItem = false;
        }
    }
}
