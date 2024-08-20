using UnityEngine;

public class FoodSpawnerScript : MonoBehaviour
{
    public GameObject food;
    public float spawnRate = 2f;
    private float nextSpawnTime;
    private float screenMinX, screenMaxX, screenMinY, screenMaxY;

    // Start is called before the first frame update
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
            SpawnFood(5f, 2f, 0.1f);
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    public void SpawnFood(float duration, float foodValue, float foodScaleValue)
    {
        float x = Random.Range(screenMinX, screenMaxX);
        float y = Random.Range(screenMinY, screenMaxY);
        Vector2 spawnPosition = new Vector2(x, y);

        GameObject foodPreFab = Instantiate(food, spawnPosition, Quaternion.identity);

        FoodScript foodScript = foodPreFab.GetComponent<FoodScript>();
        if (foodScript != null)
        {
            foodScript.duration = duration;
            foodScript.foodValue = foodValue;
            foodScript.foodScaleValue = foodScaleValue;
        }
    }
}
