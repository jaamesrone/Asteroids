using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnAsteroid : MonoBehaviour
{
    
    public GameObject[] asteroids;
    public Vector3 spawnValues;
    public int asteroidCount;
    public float spawnWait;
    public float startWait;

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
               asteroid = Instantiate(asteroid, spawnPosition, spawnRotation);
                yield return new WaitForSeconds(spawnWait);
            }
        }
    }

    private void Update()
    {
        asteroids = GameObject.FindGameObjectsWithTag("Asteroid"); // Checks if enemies are available with tag "Enemy". Note that you should set this to your enemies in the inspector.
        if (asteroids.Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}

