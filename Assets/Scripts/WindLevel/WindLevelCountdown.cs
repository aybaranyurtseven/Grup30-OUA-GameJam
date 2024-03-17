using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WindLevelCountdown : MonoBehaviour
{
    public float countdownTime = 120f; // Geri sayım süresi (saniye)
    public TextMeshProUGUI countdownText; // Geri sayım metni için UI Text bileşeni
    private float currentTime; // Şu anki geri sayım süresi
    public WindLevelEndGame end;
    public void Start()
    {
        currentTime = countdownTime;
        end = GameObject.Find("GameManager").GetComponent<WindLevelEndGame>();
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
        countdownText.text = "Süre: " + seconds.ToString();
    }
}
