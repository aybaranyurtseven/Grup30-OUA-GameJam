using TMPro;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int score = 0; // Skor değeri
    public TextMeshProUGUI scoreText; // Skor metni için UI Text bileşeni
    public EndGame end;
    private void Start()
    {
        // Başlangıçta skor metnini güncelle
        UpdateScoreText();
        end = GameObject.Find("GameController").GetComponent<EndGame>();
    }

    // Skoru artırmak için çağrılacak fonksiyon
    public void IncreaseScore(int amount)
    {
        score += amount; // Skoru artır
        // Skor metnini güncelle
        if (score == 200)
        {
            end.Victory();
        }
        UpdateScoreText();
    }

    // Skor metnini güncellemek için fonksiyon
    private void UpdateScoreText()
    {
        // Skor metnini güncelle
        scoreText.text = "Score: " + score.ToString();
    }
}