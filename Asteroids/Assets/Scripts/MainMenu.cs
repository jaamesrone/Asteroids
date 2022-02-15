using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    public GameObject clickStart;

    public void PlayGame()
    {
        Debug.Log("are u turning off?");
        clickStart.SetActive(false); 
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void onSave()
    {
        PlayerPrefs.SetInt("lives", GameManager.Instance.lives);
        PlayerPrefs.SetInt("score", GameManager.Instance.score);

    }

    public void onLoad()
    {
        PlayerPrefs.GetInt("score");
        PlayerPrefs.GetInt("lives");
        PlayerPrefs.GetInt("level");

        GameManager.Instance.ScoreDetection(PlayerPrefs.GetInt("score"));
        GameManager.Instance.ScoreDetection(PlayerPrefs.GetInt("lives"));
        Debug.Log("are u turning off?");
        PlayGame();
    }
}
