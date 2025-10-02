using UnityEngine;

public class KnifeAnimationThrow : MonoBehaviour
{
    public GameObject thrownKnife;
    public Transform spawnPoint;
    public GameObject parent;
    private Transform orientation;

    private void Start()
    {
        orientation = GameObject.FindGameObjectWithTag("CameraHolder").transform;
    }

    void Throw()
    {
        Instantiate(thrownKnife, spawnPoint.position, orientation.rotation);
        Destroy(parent.gameObject);
    }
}
