using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel4 : MonoBehaviour
{
    public Button continueButton;
    
    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 7);
    }

    void Update()
    {
        
    }
}
