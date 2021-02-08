using UnityEngine;

public class Rocket : Enemy
{
    private Rigidbody2D rb;

    [SerializeField] private float speed = 4f;
    [SerializeField] private GameObject explosionObject;
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
    }

    public void FixedUpdate()
    {
        ApplyMovement();    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<Bullet>().shooterTag == "Player")
            {
                Destroy(collision.gameObject);
                health -= collision.gameObject.GetComponent<Bullet>().damage;
            }
        }

        if (collision.gameObject.tag == "Player" || health <= 0)
        {
            Destroy(this.gameObject);

            GameObject explosion = Instantiate(explosionObject, transform.position, Quaternion.identity);
            Destroy(explosion, 1.5f);
        }

    }

    private void OnDestroy()
    {
        FindObjectOfType<ProgressDot>().AddProgress();
    }

    private void ApplyMovement()
    {
        rb.AddForce(Vector2.left * speed);
    }

}
