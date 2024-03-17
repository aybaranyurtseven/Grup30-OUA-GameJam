using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class NextLevel4 : MonoBehaviour
{
    public Button continueButton;
    
    
    // Start is called before the first frame update
    void Start()
    {
        continueButton.onClick.AddListener(ShowNextPage);
    }

    void ShowNextPage()
    {
        SceneManager.LoadScene(sceneBuildIndex: 7);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
