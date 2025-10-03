using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class JuiceHealth : MonoBehaviour
{
    int holes = 0;
    public Vector3 holePos;
    public Quaternion holeRot;
    private Vector3 oldHolePos;

    public float health;
    public float sinkSpeed;
    private bool died;

    public GameObject leakPS;
    public GameObject decal;

    public Animator anim;

    private List<GameObject> spawnedEffects = new List<GameObject>();

    private void Start()
    {
        oldHolePos = holePos;
    }

    private void Update()
    {
        if (oldHolePos != holePos)
        {
            GameObject spawnedPS = Instantiate(leakPS, holePos, holeRot);
            spawnedPS.transform.SetParent(transform, false);
            holeRot = Quaternion.Euler(90f, holeRot.eulerAngles.y, holeRot.eulerAngles.z);
            GameObject spawnedDecal = Instantiate(decal, holePos, holeRot);
            spawnedDecal.transform.SetParent(transform, false);
            spawnedEffects.Add(spawnedPS);
            spawnedEffects.Add(spawnedDecal);
            holes++;
            oldHolePos = holePos;
        }

        Sinking();

        if (health <= 0 && died == false)
        {
            Die();
            died = true;
        }
    }

    void Sinking()
    {
        if (holes == 1)
        {
            health -= Time.deltaTime * sinkSpeed;
        }
        else if (holes == 2)
        {
            health -= Time.deltaTime * (sinkSpeed * 2);
        }
        else if (holes == 3)
        {
            health -= Time.deltaTime * (sinkSpeed * 5);
        }
        else if (holes == 4)
        {
            health -= Time.deltaTime * (sinkSpeed * 10);
        }
    }

    void Die()
    {
        anim.SetTrigger("Die");
        StartCoroutine(DestroyCarton());
    }

    IEnumerator DestroyCarton()
    {
        for (int i = 0; i < spawnedEffects.Count; i++)
        {
            Destroy(spawnedEffects[i].gameObject);
        }

        yield return new WaitForSeconds(2f);

        Destroy(gameObject);
    }
}
