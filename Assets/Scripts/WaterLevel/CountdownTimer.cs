using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    public float countdownTime = 60f; // Geri sayım süresi (saniye)
    public TextMeshProUGUI countdownText; // Geri sayım metni için UI Text bileşeni
    private float currentTime; // Şu anki geri sayım süresi
    public EndGame end;
    public void Start()
    {
        currentTime = countdownTime;
        end = GameObject.Find("GameController").GetComponent<EndGame>();
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
