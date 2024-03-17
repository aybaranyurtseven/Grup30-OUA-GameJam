using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelSc : MonoBehaviour
{
    public GameObject levelStartPanel;

    public Button continueButton;
    public Button levelStartButton;
    
    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
        levelStartButton.onClick.AddListener(StartLevel);
    }

    void StartLevel()
    {
        SceneManager.LoadScene(sceneBuildIndex: 5);
    }
    void ShowNextPage()
    {
        levelStartPanel.SetActive(true);
        
    }
    
    
}
