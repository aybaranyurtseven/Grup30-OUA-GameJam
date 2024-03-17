using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    public float playerSpeed;
    private Rigidbody2D _rigidbody;
    private Vector2 playerDirection;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical"); 
        playerDirection = new Vector2(0, directionY).normalized;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = new Vector2(0, playerDirection.y * playerSpeed);
    }
}
