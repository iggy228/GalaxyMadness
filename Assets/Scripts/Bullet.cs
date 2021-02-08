using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public int damage = 1;
    public float speed;
    public string shooterTag;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        rb.velocity = transform.right * speed;
    }
}
