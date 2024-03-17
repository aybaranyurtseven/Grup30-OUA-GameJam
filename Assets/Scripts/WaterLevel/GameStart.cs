using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject startPanel;
    private bool gameStarted = false;

    private void Start()
    {
        Time.timeScale = 0f;
    }
    
    public void StartGame()
    {
        gameStarted = true;
       
        Time.timeScale = 1f;

        startPanel.SetActive(false);
    }
}
