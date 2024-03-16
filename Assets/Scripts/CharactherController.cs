using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactherController : MonoBehaviour
{
    public float speed = 2.8f;
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 characterPos;
    private SpriteRenderer _spriteRenderer;

    
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>(); //caching 
        _animator = GetComponent<Animator>();
        characterPos = transform.position;
        
    }

    public void FixedUpdate()
    {
        //r2d.velocity = new Vector2(speed, 0f);
    }

    
    void Update() //per frame 
    {
        characterPos = new Vector3(characterPos.x + (Input.GetAxis("Horizontal") * speed * Time.deltaTime), characterPos.y);
        transform.position = characterPos; 
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }
        else
        {
            _animator.SetFloat("speed", speed);
        }
        if (Input.GetAxis("Horizontal") > 0.01f)
        {
            _spriteRenderer.flipX = false;
        }
        else if(Input.GetAxis("Horizontal") < -0.01f)
        {
            _spriteRenderer.flipX = true;
        }
    }
    
    public void PlayCollisionAnimation()
    {
        // Karakterin çarpma animasyonunu başlat
        // Örneğin:
        GetComponent<Animator>().SetTrigger("Collision");
    }
}
