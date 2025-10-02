using UnityEngine;

public class Straw : MonoBehaviour
{
    public Transform target;
    private Transform player;

    public float distanceFromStraw = 0.5f; // How far the target sits from straw base
    public float followSpeed = 5f; // Smooth follow
    public float yOffset = 1;
    public float orbitRadius = 0.1f;
    public float orbitSpeed = 2f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        Vector3 direction = (player.position - transform.position).normalized;
        Vector3 basePos = transform.position + direction * distanceFromStraw;
        basePos = new Vector3(basePos.x, basePos.y + yOffset, basePos.z);

        // Orbit offset
        float angle = Time.time * orbitSpeed;
        Vector3 orbitOffset = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * orbitRadius;

        // Rotate orbit offset so it matches direction towards player
        orbitOffset = Quaternion.LookRotation(direction) * orbitOffset;

        target.position = basePos + orbitOffset;
    }
}
