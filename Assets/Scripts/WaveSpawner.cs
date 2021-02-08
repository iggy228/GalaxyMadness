using System.Collections;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING }

    [System.Serializable]
    public class Wave
    {
        public string name;
        public GameObject enemy;
        public int count;
        public float rate;
    }

    [SerializeField] private ProgressDot progressDot;

    private int nextWave = 0;
    private BoxCollider2D box;

    public Wave[] waves;

    public SpawnState state = SpawnState.COUNTING;

    public float timeBetweenWaves = 5f;
    private float waveCountdown = 0f;

    public int GetCurrentWaweCount()
    {
        return waves[nextWave].count;
    }

    private void Start()
    {
        waveCountdown = timeBetweenWaves;
        box = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            if (!EnemyIsAlive())
            {
                nextWave++;
                waveCountdown = timeBetweenWaves;
                state = SpawnState.COUNTING;
            }
            else
            {
                return;
            }
        }

        if (waveCountdown <= 0f)
        {
            if (state != SpawnState.SPAWNING)
            {
                progressDot.max = waves[nextWave].count;
                progressDot.ResetProgress();

                StartCoroutine( SpawnWave(waves[nextWave]) );
            }
            waveCountdown = timeBetweenWaves;
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    private bool EnemyIsAlive()
    {
        if (GameObject.FindGameObjectWithTag("Enemy"))
        {
            return true;
        }
        return false;
    }

    private IEnumerator SpawnWave(Wave wave)
    {
        state = SpawnState.SPAWNING;

        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }

        state = SpawnState.WAITING;
        
        yield break;
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Vector2 position = new Vector2(
            Random.Range(transform.position.x - box.bounds.size.x / 2, transform.position.x + box.bounds.size.x / 2),
            Random.Range(transform.position.y - box.bounds.size.y / 2, transform.position.y + box.bounds.size.y / 2)
        );
        Instantiate(enemy, position, Quaternion.identity);
    }
}
