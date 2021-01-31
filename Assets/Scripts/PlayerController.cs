using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 5f;

    private float inputHorizontal;
    private float inputVertical;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    void FixedUpdate()
    {
        ApplyMovement();    
    }

    private void move()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
    }

    private void ApplyMovement()
    {
        rb.AddForce(new Vector2(
            inputHorizontal * speed,
            inputVertical * speed
        ));
    }
}
