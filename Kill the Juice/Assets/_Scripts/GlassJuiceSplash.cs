using UnityEngine;

public class GlassJuiceSplash : MonoBehaviour
{
    public BoxCollider boxCollider;

    public int damage = 10;

    private void Start()
    {
        Destroy(boxCollider, 0.1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
