using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerEnemies : MonoBehaviour
{
    [SerializeField] private float spawnRate = 1;
    [SerializeField] private GameObject[] enemyPrefabs;
    [SerializeField] private bool canSpawn = true;
    private void Start()
    {
        StartCoroutine(Spawner());
    }

    private IEnumerator Spawner () { 
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while (true)
        {
            yield return wait;

            int rand = Random.Range(0,enemyPrefabs.Length);
            GameObject enemyToSpawn = enemyPrefabs[rand];
            Instantiate(enemyToSpawn, transform.position, Quaternion.identity);


        }
    }
}
