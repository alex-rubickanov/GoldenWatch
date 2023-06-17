using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform startSpawnPoint;
    [SerializeField] private Transform[] randomSpawnPoints;
    private GameObject playerObj;
    private void Awake()
    {
        playerObj = Instantiate(playerPrefab, startSpawnPoint.position, startSpawnPoint.rotation, transform);
    }
    public void StartRespawn()
    {
        StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(3f);
        Destroy(playerObj);
        yield return new WaitForSeconds(1f);
        playerObj = Instantiate(playerPrefab, randomSpawnPoints[Random.Range(0, randomSpawnPoints.Length)].position, Quaternion.identity, transform);
    }
}
