using UnityEngine;

public class FoodSpawnerScript : MonoBehaviour
{
    public struct FoodType
    {
        public float duration;
        public float foodValue;
        public float foodScaleValue;
        public Color color;
        public FoodScript.FoodEffect? foodEffect;

        public FoodType(float duration, float foodValue, float foodScaleValue, Color color, FoodScript.FoodEffect? foodEffect)
        {
            this.duration = duration;
            this.foodValue = foodValue;
            this.foodScaleValue = foodScaleValue;
            this.color = color;
            this.foodEffect = foodEffect;
        }
    }
    public GameObject food;
    public float spawnRate = 2f;
    private float nextSpawnTime;
    private float screenMinX, screenMaxX, screenMinY, screenMaxY;
    public FoodType[] foodTypes = {new FoodType(5f, 2f, 0.1f, Color.white, FoodScript.FoodEffect.None),
                                   new FoodType(2f, 20f, 1f, Color.red, FoodScript.FoodEffect.None), 
                                   new FoodType(3f, 0f, 0f, Color.blue, FoodScript.FoodEffect.SpeedBoost)};

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
            SpawnFood(5f, 2f, 0.1f, Color.red);
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    public void SpawnFood(float duration, float foodValue, float foodScaleValue, Color color = default(Color))
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
        if (color != default(Color))
        {
            foodScript.SetColor(color);
        }
    }
}
