using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Karakterle temas etti mi kontrol et
        {
            // Karakterin çarpma animasyonunu başlat
            CharactherController player = collision.GetComponent<CharactherController>(); 
            if (player != null) 
            {
                GetComponent<BoxCollider2D>().enabled = false;
                player.PlayCollisionAnimation(); 
                ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>(); // Skor sayacını bul
                scoreCounter.IncreaseScore(10); // Skoru 10 artır
            }
        }
    }
    public AudioSource audioSource; // Ses kaynağı bileşeni
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground")) // Yere çarptığında kontrol et
            {
                audioSource.Play(); // Ses çal
            }
        }
}
