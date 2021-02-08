using UnityEngine;

public class Defender : Enemy
{
    private enum State { START, FIGHT };

    public GameObject bullet;

    public Transform normalFirePoint1;
    public Transform normalFirePoint2;
    public Transform radiusFirePoint1;
    public Transform radiusFirePoint2;

    public float normalFireTime = 1f;
    public float radiusFireTime = 3f;

    private float m_normalFireTime = 0f;
    private float m_radiusFireTime;

    private Rigidbody2D rb;
    private State state;

    private float verticalSpeed = 1f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.START;

        GameObject firePoints = GameObject.Find("FirePoints");

        m_radiusFireTime = radiusFireTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (state == State.FIGHT)
        {
            if (m_normalFireTime <= 0)
            {
                NormalFire();
                m_normalFireTime = normalFireTime;
            }
            else
            {
                m_normalFireTime -= Time.deltaTime;
            }

            if (m_radiusFireTime <= 0)
            {
                RadiusFire();
                m_radiusFireTime = normalFireTime;
            }
            else
            {
                m_radiusFireTime -= Time.deltaTime;
            }
        }
    }

    void FixedUpdate()
    {
        if (state == State.START)
        {
            StartMovement();
        }

        if (state == State.FIGHT)
        {
            FightMovement();
        }
    }

    private void StartMovement()
    {
        if (transform.position.x >= 8)
        {
            rb.velocity = Vector2.left;
        }
        else
        {
            state = State.FIGHT;
        }
    }

    private void FightMovement()
    {
        if (transform.position.y > 1 || transform.position.y < -1)
        {
            verticalSpeed = -verticalSpeed;
        }

        rb.velocity = Vector2.up * verticalSpeed;
    }

    private void NormalFire() 
    {
        GameObject bullet1 = Instantiate(bullet, normalFirePoint1.position, Quaternion.identity);
        GameObject bullet2 = Instantiate(bullet, normalFirePoint2.position, Quaternion.identity);

        bullet1.GetComponent<Bullet>().shooterTag = tag;
        bullet1.GetComponent<Bullet>().speed = -5f;

        bullet2.GetComponent<Bullet>().shooterTag = tag;
        bullet2.GetComponent<Bullet>().speed = -5f;
    }

    private void RadiusFire()
    {
        for (int i = -1; i <= 1; i++)
        {
            GameObject bulletClone = Instantiate(bullet, radiusFirePoint1.position, Quaternion.Euler(
                0f,
                0f,
                30f * i
            ));

            bulletClone.GetComponent<Bullet>().shooterTag = tag;
            bulletClone.GetComponent<Bullet>().speed = -5f;
        }

        for (int i = -1; i <= 1; i++)
        {
            GameObject bulletClone = Instantiate(bullet, radiusFirePoint2.position, Quaternion.Euler(
                0f,
                0f,
                30f * i
            ));

            bulletClone.GetComponent<Bullet>().shooterTag = tag;
            bulletClone.GetComponent<Bullet>().speed = -5f;
        }
    }
}
