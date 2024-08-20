using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public float spawnRate = 2f;
    private float nextSpawnTime;
    private float screenMinX, screenMaxX, screenMinY, screenMaxY;
    void Start()
    {
        Camera cam = Camera.main;
        screenMinX = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).x;
        screenMaxX = cam.ScreenToWorldPoint(new Vector3(Screen.width, 0, cam.nearClipPlane)).x;
        screenMinY = cam.ScreenToWorldPoint(new Vector3(0, 0, cam.nearClipPlane)).y;
        screenMaxY = cam.ScreenToWorldPoint(new Vector3(0, Screen.height, cam.nearClipPlane)).y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            SpawnEnemy(1f, 100f, 1f);
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    public void SpawnEnemy(float speed, float health, float damage)
    {
        float x = Random.Range(screenMinX, screenMaxX);
        float y = Random.Range(screenMinY, screenMaxY);
        Vector2 spawnPosition = new Vector2(x, y);
        GameObject enemyPreFab = Instantiate(enemy, spawnPosition, Quaternion.identity);
        EnemyScript enemyScript = enemyPreFab.GetComponent<EnemyScript>();
        if (enemyScript != null)
        {
            enemyScript.speed = speed;
            enemyScript.health = health;
            enemyScript.damage = damage;
        }
    }
}
