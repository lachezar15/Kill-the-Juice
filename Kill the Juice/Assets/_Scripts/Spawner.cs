using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] spawnPositions;
    private List<Vector3> currentSpawnPos = new List<Vector3>();
    private List<GameObject> aliveEnemies = new List<GameObject>();

    public GameObject[] easyJuice;

    int enemiesCount = 5;

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
        // we open the fridge and let the enemies escape
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
        }
    }
}
