using UnityEngine;

public class Knife : MonoBehaviour
{
    float timeBeforeCanAttack = 0;

    public Animator anim;

    void Update()
    {
        timeBeforeCanAttack += Time.deltaTime;

        if (Input.GetMouseButton(0) && timeBeforeCanAttack > 0.5f)
        {
            Attack();
        }
    }

    void Attack()
    {
        anim.SetTrigger("Attack");
    }
}
