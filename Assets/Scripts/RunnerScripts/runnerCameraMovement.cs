using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class runnerCameraMovement : MonoBehaviour
{

    public float cameraSpeed;

    
    void Update()
    {
        transform.position += new Vector3(cameraSpeed * Time.deltaTime, 0, 0);
    }
}
