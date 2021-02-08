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
    private float killCount = 0;


    public void addKill()
    {
        killCount++;
    }

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
            health--;
            healthText.text = health.ToString();
        }    
    }

    private void Shot()
    {
        if (m_bulletDelay <= 0)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                m_bulletDelay = bulletDelay;
                GameObject bullet = Instantiate(bulletObject, transform.position, Quaternion.identity);
                bullet.GetComponent<Bullet>().speed = bulletSpeed;
                bullet.GetComponent<Bullet>().shooterTag = gameObject.tag;
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
