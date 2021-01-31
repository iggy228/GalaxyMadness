using UnityEngine;

public class Spawner : MonoBehaviour
{
    private BoxCollider2D box;

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnTime = 5f;
    [SerializeField] private float spawnDelay = 1f;

    private float m_spawnTime;

    // Start is called before the first frame update
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        m_spawnTime = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_spawnTime <= 0f && spawnDelay <= 0f)
        {
            SpawnEnemy();
            m_spawnTime = spawnTime;
        }
        else
        {
            if (spawnDelay > 0f)
            {
                spawnDelay -= Time.deltaTime;
            }

            m_spawnTime -= Time.deltaTime;
        }
    }

    private void SpawnEnemy()
    {
        Vector2 positon = new Vector2(
            box.bounds.center.x,
            Random.Range(box.bounds.center.y - box.size.y / 2, box.bounds.center.y + box.size.y / 2)
        );
       
        Instantiate(enemy, positon, Quaternion.identity);
    }
}
