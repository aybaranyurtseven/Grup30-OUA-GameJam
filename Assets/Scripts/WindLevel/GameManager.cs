using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
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
        // Oyun sahnesini yüklemek için SceneManager'ı kullan
        Time.timeScale = 1f;

        startPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
