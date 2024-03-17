using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StoryboardController : MonoBehaviour
{
    public Image[] comicPages;
    public Button startButton;
    public Button continueButton;

    private int currentPageIndex = 0;

    void Start()
    {
        // ilk sayfayı göster
        startButton.onClick.AddListener(StartComic);
        
        // bir sonraki sayfayı göster
        continueButton.onClick.AddListener(ShowNextPage);
        
        continueButton.gameObject.SetActive(false);
        
    }

    void Update()
    {
        
    }

    void StartComic()
    {
        
        startButton.gameObject.SetActive(false);
        comicPages[currentPageIndex].gameObject.SetActive(false);
        currentPageIndex++;
        comicPages[currentPageIndex].gameObject.SetActive(true);
        
        continueButton.gameObject.SetActive(true);
    }

    void ShowNextPage()
    {
        // Mevcut sayfanın görünürlüğünü kapat
        comicPages[currentPageIndex].gameObject.SetActive(false);
        
        // Bir sonraki sayfayı göster
        currentPageIndex++;
        if (currentPageIndex < comicPages.Length)
        {
            comicPages[currentPageIndex].gameObject.SetActive(true);
        }
        else if(currentPageIndex == 8)
        {
            continueButton.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
