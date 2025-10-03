using UnityEngine;

public class KnifeThrown : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject DestroyPS;

    public GameObject glassSplash;

    public float speed;

    void Start()
    {
        rb.linearVelocity = transform.forward * speed;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            // Take the first contact
            ContactPoint contact = collision.contacts[0];

            // World-space hit point
            Vector3 collisionPoint = contact.point;

            // Surface normal -> rotation
            Quaternion hitRotation = Quaternion.LookRotation(contact.normal);

            JuiceHealth jh = collision.collider.GetComponent<JuiceHealth>();
            jh.holePos = collision.collider.transform.InverseTransformPoint(collisionPoint);
            jh.holeRot = Quaternion.Inverse(collision.collider.transform.rotation) * hitRotation;
        }

        if (collision.collider.CompareTag("GlassEnemy"))
        {
            Instantiate(glassSplash, collision.collider.transform.position, Quaternion.identity);
            Destroy(collision.collider.gameObject);
        }

        Instantiate(DestroyPS, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
