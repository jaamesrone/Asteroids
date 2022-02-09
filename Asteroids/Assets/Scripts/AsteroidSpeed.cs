using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AsteroidSpeed : MonoBehaviour
{
[SerializeField]
    private float tumble;
    


    private const float SPEED = 2f;
    private Vector3 direction;
    void Start()
    {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f)).normalized;

    }
    void Update()
    {
        transform.position += direction * SPEED * Time.deltaTime;
        GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere * tumble;
        

    }
}
