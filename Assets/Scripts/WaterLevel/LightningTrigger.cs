using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LightningTrigger : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            CharactherController player = collision.GetComponent<CharactherController>(); 
            if (player != null) 
            {
                GetComponent<BoxCollider2D>().enabled = false;
                player.PlayCollisionAnimation(); 
                ScoreCounter scoreCounter = FindObjectOfType<ScoreCounter>(); 
                scoreCounter.IncreaseScore(10); 
            }
        }
    }
    public AudioSource audioSource; 
    private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Ground")) 
            {
                audioSource.Play(); 
            }
        }
}
