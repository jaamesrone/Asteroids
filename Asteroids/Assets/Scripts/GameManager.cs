using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI scoreText;

    public static GameManager Instance;

    private void Awake()
    {
       Instance = this;
    }

    public void Start()
    {
        score = 0;
        scoreText.text = "Score : " + score.ToString();
    }

    public void SmallScore()
    {
        score += 75;
        scoreText.text = "Score : " + score.ToString();
    }
    public void MediumScore()
    {
        score += 25;
        scoreText.text = "Score : " + score.ToString();
    }
    public void LargeScore()
    {
        score += 10;
        scoreText.text = "Score : " + score.ToString();

    }
}
