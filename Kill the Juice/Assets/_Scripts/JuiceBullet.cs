using UnityEngine;

public class JuiceBullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody rb;

    public int damage = 10;

    private void Update()
    {
        transform.Translate(-Vector3.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject);
        }

        Destroy(gameObject);
    }
}
