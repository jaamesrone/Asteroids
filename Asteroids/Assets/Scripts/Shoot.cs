using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float speed;
    public Rigidbody rb;
    public float DestroyAfterSeconds = 3f;


void Start()
{
    rb.velocity = transform.forward * speed; 
}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            Destroy(this.gameObject);
        }
        if (collision.gameObject.CompareTag("Boundary"))
        {
            Destroy(this.gameObject);
        }

    }
}
