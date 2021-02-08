using UnityEngine;

public class Rocket : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private GameObject explosionObject;
    [SerializeField] private float speed = 4f;
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
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "Bullet")
        {
            // Delete incoming bullet
            if (collision.gameObject.tag == "Bullet")
            {
                Destroy(collision.gameObject);
            }

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
