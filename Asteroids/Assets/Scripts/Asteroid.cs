using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Asteroid : MonoBehaviour
{
    public Rigidbody rb;
    public const float SPEED = 100f;
    public float time = 0.1f;
    public bool canSplit = true;
    public bool isDead = false;
    public int scoreValue;
    public int maxValue;
    private Vector3 direction;

    void Start()
    {
        direction = (new Vector3(Random.Range(-1.0f, 1.0f), Random.Range(-1.0f, 1.0f), 0.0f)).normalized;
        rb = GetComponent<Rigidbody>();
        //rb.velocity += direction * SPEED * Time.deltaTime;
    }

    void FixedUpdate()
    {
        AsteroidMovement();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.RespawnShip();
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            if (scoreValue < maxValue && canSplit)
            {
                SplitAsteroid();
            }
            Debug.Log("Im i hitting????");
            Destroy(collision.gameObject);
            Destroy(gameObject);
            GameManager.Instance.ScoreDetection(scoreValue);
            isDead = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            GameManager.Instance.RespawnShip();
        }
    }

    private void SplitAsteroid()
    {
        Debug.Log("im i hitting");
        canSplit = false;
        CreateSplit();
        CreateSplit();
        isDead = true;
    }
    public void CreateSplit()
    {
        Vector2 position = this.transform.position;
        position += Random.insideUnitCircle * 0.5f;
        Rigidbody rb = Instantiate(this.gameObject, position, this.transform.rotation).GetComponent<Rigidbody>();
        canSplit = false;
        rb.velocity += direction * Time.deltaTime;
    }

    private void AsteroidMovement()
    {
        rb.AddForce(direction* SPEED, ForceMode.Force);
    }
}

