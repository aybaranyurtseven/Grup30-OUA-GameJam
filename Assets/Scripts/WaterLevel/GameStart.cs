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

    // Butona tıklandığında çağrılacak fonksiyon
    public void StartGame()
    {
        gameStarted = true;
        // Oyun sahnesini yüklemek için SceneManager'ı kullan
        Time.timeScale = 1f;

        startPanel.SetActive(false);
    }
}
