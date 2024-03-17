using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class StartingCanvas : MonoBehaviour
{
    public GameObject[] gameObjectsToActivate;

    public void StartGame()
    {
        foreach (GameObject obj in gameObjectsToActivate)
        {
            obj.SetActive(true);
        }

        gameObject.SetActive(false); // Deactivate the button itself after clicking
    }
}
