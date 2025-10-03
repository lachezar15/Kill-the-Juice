using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    private List<Vector3> currentSpawnPos = new List<Vector3>();
    private List<GameObject> aliveEnemies = new List<GameObject>();

    public GameObject[] easyJuice;

    int currentWave = 0;

    public int enemiesCount = 5;

    public Animator fridgeAnim;
    public Animator fridgeAnim2;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    void GetPositions()
    {
        for (int i = 0; i < spawnPositions.Length; i++)
        {
            currentSpawnPos.Add(spawnPositions[i].transform.position);
        }
    }

    void SpawnEnemiesAtPos()
    {
        for (int i = 0; i < enemiesCount; i++)
        {
            int rand = Random.Range(0, currentSpawnPos.Count);
            Vector3 spawnPos = currentSpawnPos[rand];

            GameObject spawnedGO = Instantiate(easyJuice[0], spawnPos, Quaternion.identity);

            aliveEnemies.Add(spawnedGO);

            currentSpawnPos.RemoveAt(rand);
        }
    }

    void OpenFridge()
    {
        fridgeAnim.SetBool("Opened", true);
        fridgeAnim2.SetBool("Opened", true);
        for (int i = 0; i < aliveEnemies.Count; i++)
        {
            if (aliveEnemies[i].tag == "Enemy")
                aliveEnemies[i].GetComponent<JuiceMovement>().releasedFromFridge = true;

            if (aliveEnemies[i].tag == "GlassEnemy")
                aliveEnemies[i].GetComponent<GlassJuiceMovement>().releasedFromFridge = true;
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            GetPositions();
            SpawnEnemiesAtPos();

            yield return new WaitForSeconds(5);

            currentSpawnPos.Clear();
            OpenFridge();

            yield return new WaitUntil(() => aliveEnemies.TrueForAll(e => e == null));

            aliveEnemies.Clear();
            currentWave++;
        }
    }
}
