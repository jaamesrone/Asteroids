using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
public float speed;
public Rigidbody rb;
    public int score;


void Start()
{
    rb.velocity = transform.up * speed;
}
     

    private void Update()
    {
      
    }

 
     private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Small")
        {
            Debug.Log("im i hitting");
            Destroy(other.gameObject);
            score += 50;
            GameManager.Instance.SmallScore();
        }
        if (other.gameObject.tag == "Medium")
        {
            Debug.Log("im i hitting");
            Destroy(other.gameObject);
            score += 25;
            GameManager.Instance.MediumScore();
        }
        if (other.gameObject.tag == "Large")
        {
            Debug.Log("im i hitting");
            Destroy(other.gameObject);
            score += 10;
            GameManager.Instance.LargeScore();
        }
    }
    
}
