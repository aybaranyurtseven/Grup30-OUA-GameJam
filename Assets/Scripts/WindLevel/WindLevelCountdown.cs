using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindLevelCountdown : MonoBehaviour
{
    public float countdownTime = 120f; 
    public TextMeshProUGUI countdownText; 
    private float currentTime; 
    public WindLevelEndGame end;
    public void Start()
    {
        currentTime = countdownTime;
        end = GameObject.Find("GameManager").GetComponent<WindLevelEndGame>();
    }

    private void Update()
    {
        currentTime -= Time.deltaTime;
        
        if (currentTime <= 0)
        {
            currentTime = 0;
            end.GameOver();
        }
        
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        countdownText.text = "Süre: " + seconds.ToString();
    }
}
