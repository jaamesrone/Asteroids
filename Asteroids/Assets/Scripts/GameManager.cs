using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;
    public GameObject Player;
    public Transform playerSpawnPoint;
    public int score;
    public int lives;
    

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    public void Start()
    { 
        lives = 3;
        score = 0;
        Score();
        Lives();
    }

    public void ScoreDetection(int amountToAdd)
    { 
        score += amountToAdd;
        Score();
    }
    public void RespawnShip()
    {
        Player.transform.position = playerSpawnPoint.position;
        lives--;
        Lives();
        if (lives <= 0)
        {
            Destroy(GameObject.FindGameObjectWithTag("Player"));
            SceneManager.LoadScene(0);
        }
    }

    public void Score()
    {
        scoreText.text = "Score : " + score.ToString();
    }

    public void Lives()
    {
        
        livesText.text = "Lives : " + lives.ToString();
    }

    public void Ufo()
    {
        score += 75;
        Score();
    }
        
}
