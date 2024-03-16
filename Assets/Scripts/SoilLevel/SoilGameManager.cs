using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoilGameManager : MonoBehaviour
{
    [SerializeField] private List<EarthHill> soils;

    [SerializeField] GameObject _playButton;
    [SerializeField] GameObject _gameUI;
    [SerializeField] GameObject _outOfTimeText;
    [SerializeField] GameObject _viperText;
    [SerializeField] TMPro.TextMeshProUGUI _timeText;
    [SerializeField] TMPro.TextMeshProUGUI _scoreText;

    float startingTime = 30f;
    float timeRemaining;
    HashSet<EarthHill> currentSoils = new HashSet<EarthHill>();
    int score;
    bool playing = false;


    public void StartGame()
    {
        _playButton.SetActive(false);
        _outOfTimeText.SetActive(false);
        _viperText.SetActive(false);
        _gameUI.SetActive(true);

        for (int i = 0; i < soils.Count; i++)
        {
            soils[i].Hide();
            soils[i].SetIndex(i);
        }

        currentSoils.Clear();

        timeRemaining = startingTime;
        score = 0;
        _scoreText.text = "0";
        playing = true;
    }

    public void GameOver(int type)
    {

        if (type == 0)
        {
            _outOfTimeText.SetActive(true);
        }
        else
        {
            _viperText.SetActive(true);
        }

        foreach (EarthHill soil in soils)
        {
            soil.StopGame();
        }

        playing = false;
        _playButton.SetActive(true);
    }

    private void Update()
    {
        if (playing)
        {
            timeRemaining -= Time.deltaTime;
            if (timeRemaining <= 0)
            {
                timeRemaining = 0;
                GameOver(0);
            }
            _timeText.text = $"{(int)timeRemaining / 60} : {(int)timeRemaining % 60:D2}";
            if (currentSoils.Count <= (score / 10))
            {
                int index = Random.Range(0, soils.Count);

                if (!currentSoils.Contains(soils[index]))
                {
                    currentSoils.Add(soils[index]);
                    soils[index].Activate(score / 10);
                }
            }
        }
    }

    public void AddScore(int soilIndex)
    {
        score += 1;
        _scoreText.text = $"{score}";
        timeRemaining += 1;
        currentSoils.Remove(soils[soilIndex]);
    }

    public void Missed(int soilIndex, bool isSoil)
    {
        if (isSoil)
        {
            timeRemaining -= 2;
        }
        currentSoils.Remove(soils[soilIndex]);
    }
}
