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
        // Zamanı azalt
        currentTime -= Time.deltaTime;

        // Zamanı sıfıra düşürme durumu
        if (currentTime <= 0)
        {
            currentTime = 0;
            end.GameOver();
        }

        // Geri sayım metnini güncelle
        UpdateCountdownText();
    }

    private void UpdateCountdownText()
    {
        // Zamanı düzgün formatta göstermek için metni güncelle
        int seconds = Mathf.CeilToInt(currentTime);
        countdownText.text = "Countdown: " + seconds.ToString();
    }
}
