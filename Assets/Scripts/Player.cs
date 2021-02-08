using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private int health = 3;
    [SerializeField] private int damage = 1;
    [SerializeField] private float bulletDelay = 1f;
    [SerializeField] private float bulletSpeed = 5f;

    [SerializeField] private GameObject explosionObject;
    [SerializeField] private GameObject bulletObject;
    [SerializeField] private Text healthText;

    private float m_bulletDelay;

    private void Start()
    {
        healthText.text = health.ToString();
        m_bulletDelay = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();

        if (health <= 0)
        {
            Death();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health -= collision.gameObject.GetComponent<Enemy>().GetDamage();
        }

        if (collision.gameObject.tag == "Bullet")
        {
            if (collision.gameObject.GetComponent<Bullet>().shooterTag != "Player")
            {
                Destroy(collision.gameObject);
                health -= collision.gameObject.GetComponent<Bullet>().damage;
            }
        }

        healthText.text = health.ToString();

    }

    private void Shot()
    {
        if (m_bulletDelay <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_bulletDelay = bulletDelay;
                GameObject bulletClone = Instantiate(bulletObject, transform.position, Quaternion.identity);
                Bullet bullet = bulletClone.GetComponent<Bullet>();
                bullet.speed = bulletSpeed;
                bullet.shooterTag = tag;
            }
        }
        else
        {
            m_bulletDelay -= Time.deltaTime;
        }
    }

    private void Death()
    {
        Destroy(this.gameObject);
        GameObject explosion = Instantiate(explosionObject, transform.position, Quaternion.identity);
        Destroy(explosion, 1.5f);
    }
}
