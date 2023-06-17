using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawningObj : MonoBehaviour
{
    [SerializeField] Transform [] positions;
    [SerializeField] GameObject[] powerUps;
    [SerializeField] float minSpawnTime = 5f;
    [SerializeField] float maxSpawnTime = 10f;
    void Start()
    {
        StartCoroutine(SpawnPowerUps());
    }

    IEnumerator SpawnPowerUps()
    {
        while(true)
        {
            float randomSpawnTime = Random.Range(minSpawnTime, maxSpawnTime);
            yield return new WaitForSeconds(randomSpawnTime);
            int randomPowerUps = Random.Range(0, powerUps.Length);
            int randomPos = Random.Range(0, positions.Length);
            Instantiate(powerUps[randomPowerUps], positions[randomPos].position, Quaternion.identity);
        }
    }
}
