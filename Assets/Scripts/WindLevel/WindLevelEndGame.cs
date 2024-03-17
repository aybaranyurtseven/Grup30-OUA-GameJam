using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WindLevelEndGame : MonoBehaviour
{
    public GameObject gameOverPanel; 
    public GameObject victoryPanel; 

    public void Start()
    {
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        gameOverPanel.SetActive(true);
        Time.timeScale = 0;
    }

    public void Victory()
    {
        victoryPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void RestartLevel()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneBuildIndex:2);
    }
}
