using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loopingBackground : MonoBehaviour
{
    public float backgroundSpeed;
    public Renderer _backgroundRenderer;

    
    void Update()
    {
        _backgroundRenderer.material.mainTextureOffset += new Vector2(backgroundSpeed * Time.deltaTime, 0f);
    }
}
