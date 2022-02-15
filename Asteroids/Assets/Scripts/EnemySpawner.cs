using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyObject;
    public float secondsBeforeEnemySpawn;
    public float TimeTillSpawn = 0.0f;

    void Update()
    {
        TimeTillSpawn += Time.deltaTime;

        if (TimeTillSpawn > secondsBeforeEnemySpawn)
        {
            TimeTillSpawn = 0;
            Debug.Log(true);
            Vector3 spawnPosition = new Vector3(-7, 5, 0f);
            GameObject newEnemy = (GameObject)Instantiate(enemyObject, spawnPosition, Quaternion.Euler(0, 0, 0));
        }
    }
}
