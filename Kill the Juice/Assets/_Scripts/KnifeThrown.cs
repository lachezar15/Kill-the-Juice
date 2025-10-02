using UnityEngine;

public class KnifeThrown : MonoBehaviour
{
    public Rigidbody rb;

    public float speed;

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
