using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NextLevelSc : MonoBehaviour
{
    public GameObject levelStartPanel;
    // Start is called before the first frame update
    public Button continueButton;
    public Button levelStartButton;
    
    
    // Start is called before the first frame update
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
