using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shoot : MonoBehaviour
{
public float speed;
public Rigidbody rb;
public TextMeshProUGUI scoreUI;
public int score;


void Start()
{
    rb.velocity = transform.up * speed;
    score = 0;
}
     

    private void Update()
    {
      
    }

    private void DisplayScoreUI()
    {
     scoreUI.text = "Score: " + score.ToString();
    }

     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("im i hitting");
             Destroy(other.gameObject);
             score++;
             DisplayScoreUI();
            
        }
    }
    
}
