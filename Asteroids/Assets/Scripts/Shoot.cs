using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
public float speed;
public Rigidbody rb;
public TextMeshProUGUI scoreUI;
private int score;


void Start()
{
    rb.velocity = transform.up * speed;
}
     

    private void Update()
    {
      
    }

 
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("im i hitting");
            Destroy(other.gameObject);
            GameManager._instance.AddScore();
        }
    }
    
}
