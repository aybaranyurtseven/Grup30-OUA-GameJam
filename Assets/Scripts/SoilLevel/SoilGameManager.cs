using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SoilGameManager : MonoBehaviour
{
    [SerializeField] private List<EarthHill> soils;
    private EarthHill _earthHill;
    public AudioSource clickSound;
    public AudioSource failSound;
    public AudioSource successSound;

    public Button nextLevelButton;
    [SerializeField] GameObject _playButton;
    [SerializeField] GameObject _playScreen;
    [SerializeField] GameObject _gameUI;
    [SerializeField] GameObject _outOfTimeText;
    [SerializeField] GameObject _viperText;
    [SerializeField] GameObject _winText;
    [SerializeField] TMPro.TextMeshProUGUI _timeText;
    [SerializeField] TMPro.TextMeshProUGUI _scoreText;

    float startingTime = 30f;
    float timeRemaining;
    HashSet<EarthHill> currentSoils = new HashSet<EarthHill>();
    int score;
    bool playing = false;


    public void StartGame()
    {
        nextLevelButton.onClick.AddListener(ShowFinalPage);
        _playButton.SetActive(false);
        _playScreen.SetActive(false);
        _outOfTimeText.SetActive(false);
        _viperText.SetActive(false);
        _winText.SetActive(false);
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

    public void ShowFinalPage()
    { 
        SceneManager.LoadScene(sceneBuildIndex: 8);
    }
    public void GameOver(int type)
    {
        if (type == 1)
        {
            successSound.Play();
            _winText.SetActive(true);
            playing = false;
        }
        else if (type == 0)
        {
            failSound.Play();
            _outOfTimeText.SetActive(true);
            playing = false;
            _playButton.SetActive(true);
        }
        else
        {
            failSound.Play();
            _viperText.SetActive(true);
            playing = false;
            _playButton.SetActive(true);
        }

        foreach (EarthHill soil in soils)
        {
            soil.StopGame();
        }
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
            if (score == 75)
            {
                GameOver(1);
            }
        }
    }

    public void AddScore(int soilIndex)
    {
        score += 1;
        clickSound.Play();
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
