using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject nextLevelPanel;
    public ScoreManager score;

    void Start()
    {
        score = gameObject.GetComponent<ScoreManager>();

        if(score.score >= 30)
        {
            nextLevelPanel.SetActive(true);
        }
    }
}
