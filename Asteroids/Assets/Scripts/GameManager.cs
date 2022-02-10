using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreUI;
    public static GameManager _instance;
    

    public int score;


   
    // Start is called before the first frame update
    void Start()
    {
       
    }

   
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        } else {
            _instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     
    

    public void AddScore()
    {
        score++;
        scoreUI.text = "Score: " + score.ToString();
    }
       
}
