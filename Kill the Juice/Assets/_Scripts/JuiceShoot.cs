using UnityEngine;

public class JuiceShoot : MonoBehaviour
{
    public JuiceMovement juiceMovement;
    public Transform shootPoint;
    public GameObject bullet;
    public Animator anim;

    public float shotSpeed;
    private float timeBtwShots;

    private void Update()
    {
        timeBtwShots += Time.deltaTime;

        if (timeBtwShots >= shotSpeed && juiceMovement.inAttackRange == true)
        {
            Shoot();
            timeBtwShots = 0;
        }
    }

    void Shoot()
    {
        anim.SetTrigger("Shoot");
        Instantiate(bullet, shootPoint.position, shootPoint.rotation);
    }

}
