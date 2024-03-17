using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Button nextLevelButton;
    public GameObject startPanel;
    private bool gameStarted = false;
    public GameObject PipesHolder;
    public GameObject[] Pipes;
    public WindLevelEndGame end;
    
    [SerializeField]
    public int totalPipes = 0;
    [SerializeField]
    int correctedPipes = 0;
    void Start()
    {
        Time.timeScale = 0f;
        
        nextLevelButton.onClick.AddListener(NextPage);
        
        end = GameObject.Find("GameManager").GetComponent<WindLevelEndGame>();
        
        totalPipes = PipesHolder.transform.childCount;

        Pipes = new GameObject[totalPipes];
        
        for (int i = 0; i < Pipes.Length; i++)
        {
            Pipes[i] = PipesHolder.transform.GetChild(i).gameObject;
        }
    }

    public void CorrectMove()
    {
        correctedPipes += 1;
        
        if (correctedPipes == totalPipes-8)
        {
            end.Victory();
        }
    }
    
    public void WrongMove()
    {
        correctedPipes -= 1;
    }
    
    public void StartGame()
    {
        gameStarted = true;
        
        Time.timeScale = 1f;

        startPanel.SetActive(false);
    }

   
    void Update()
    {
        
    }

    public void NextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 4);
    }
}
