using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnAsteroid : MonoBehaviour
{
    public GameObject[] asteroids;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;
    public float waveWait;

    void Start()
    {
        StartCoroutine(spawnWaves());
    }

    IEnumerator spawnWaves()
    {

       

        while (asteroidCount > 0)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject asteroid = asteroids[Random.Range(0, asteroids.Length)];
                Vector3 spawnPosition = new Vector3(spawnValues.x, Random.Range(-spawnValues.y, spawnValues.y), spawnValues.z);
                Quaternion spawnRotation = Quaternion.identity;
                Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }
}

