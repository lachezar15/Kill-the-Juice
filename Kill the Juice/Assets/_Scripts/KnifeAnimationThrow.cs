using UnityEngine;

public class KnifeAnimationThrow : MonoBehaviour
{
    public GameObject thrownKnife;
    public Transform spawnPoint;
    public GameObject parent;
    private Transform orientation;
    private PlayerInventory playerInventory;

    private void Start()
    {
        orientation = GameObject.FindGameObjectWithTag("CameraHolder").transform;
        playerInventory = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInventory>();
    }

    void Throw()
    {
        playerInventory.hasItem = false;
        Instantiate(thrownKnife, spawnPoint.position, orientation.rotation);
        Destroy(parent.gameObject);
    }
}
