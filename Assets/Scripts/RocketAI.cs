using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketAI : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 4f;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    public void FixedUpdate()
    {
        ApplyMovement();    
    }

    private void ApplyMovement()
    {
        rb.AddForce(Vector2.left * speed);
    }
}
