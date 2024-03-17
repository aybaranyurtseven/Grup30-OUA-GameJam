using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0; 
    public TextMeshProUGUI scoreText; 
    public EndGame end;
    private void Start()
    {
        UpdateScoreText();
        end = GameObject.Find("GameController").GetComponent<EndGame>();
    }
    
    public void IncreaseScore(int amount)
    {
        score += amount; 
       
        if (score == 200)
        {
            end.Victory();
        }
        UpdateScoreText();
    }

    
    private void UpdateScoreText()
    {
        scoreText.text = "Skor: " + score.ToString();
    }
}