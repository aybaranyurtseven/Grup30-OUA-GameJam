using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public GameObject nextLevelPanel;
    public float score;
    
    
    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime;
            scoreText.text = ((int)score).ToString();

            if (score >= 30)
            {
                OpenNextLevelPanel();
            }
        }

        void OpenNextLevelPanel()
        {
            // Check if the next level panel reference is set
            if (nextLevelPanel != null)
            {
                // Activate the next level panel
                nextLevelPanel.SetActive(true);
                Time.timeScale = 0;
            }
        }
    }

   
}
