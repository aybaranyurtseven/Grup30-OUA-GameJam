using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button continueButton;
   
    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    void Update()
    {
        
    }
}
