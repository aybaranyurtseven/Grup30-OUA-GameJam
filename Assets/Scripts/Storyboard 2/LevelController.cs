using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    public Button continueButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 3);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
