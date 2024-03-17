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
        // Başla butonuna tıklanınca ilk sayfayı göster
        startButton.onClick.AddListener(StartComic);
        
        // Devam et butonuna tıklanınca bir sonraki sayfayı göster
        continueButton.onClick.AddListener(ShowNextPage);
        
        continueButton.gameObject.SetActive(false);
        //startButton.gameObject.SetActive(true);
    }

    void Update()
    {
        
    }

    void StartComic()
    {
        // Başla butonunu devre dışı bırak ve ilk sayfayı göster
        startButton.gameObject.SetActive(false);
        comicPages[currentPageIndex].gameObject.SetActive(false);
        currentPageIndex++;
        comicPages[currentPageIndex].gameObject.SetActive(true);
        // Devam et butonunu etkinleştir
        continueButton.gameObject.SetActive(true);
    }

    void ShowNextPage()
    {
        // Mevcut sayfayı devre dışı bırak
        comicPages[currentPageIndex].gameObject.SetActive(false);
        
        // Bir sonraki sayfayı göster
        currentPageIndex++;
        if (currentPageIndex < comicPages.Length)
        {
            comicPages[currentPageIndex].gameObject.SetActive(true);
        }
        else if(currentPageIndex == 8)
        {
            // Eğer son sayfadaysak, devam et butonunu ve sayfaları kapat
            continueButton.gameObject.SetActive(false);
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
