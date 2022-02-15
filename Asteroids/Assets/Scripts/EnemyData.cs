using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyData : MonoBehaviour
{
    public float speed;
    public float stoppingDist;
    public float goAwayDist;
    private float waitTime;
    public float Shooting;
    public GameObject Saucer;
    public Transform player;
    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        waitTime = Shooting;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyHandle();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.Instance.RespawnShip();
            Destroy(other.gameObject);
            //Destroy(gameObject);
        }
        if (other.gameObject.tag == "Bullet")
        {
            //Debug.Log("im i hitting");
            Destroy(gameObject);
            GameManager.Instance.Ufo();

        }
    }

    private void EnemyHandle()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) > stoppingDist && Vector2.Distance(transform.position, player.position) > goAwayDist)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) > goAwayDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }

        if (waitTime <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            waitTime = Shooting;
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
}
