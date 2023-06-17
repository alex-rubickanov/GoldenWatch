using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    private GameObject playerObj;
    private void Awake()
    {
        playerObj = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation, transform);
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
        playerObj = Instantiate(playerPrefab, spawnPoint.position, spawnPoint.rotation, transform);
    }
}
