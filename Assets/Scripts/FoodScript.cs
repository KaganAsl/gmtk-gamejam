using UnityEngine;
using UnityEngine.UI;

public class FoodScript : MonoBehaviour
{
    public float duration;
    private float startTime;
    private Slider slider;

    void Start()
    {
        startTime = Time.time;

        slider = GetComponentInChildren<Slider>();
        if (slider != null)
        {
            slider.maxValue = duration; // Set the slider's max value to the duration
        }
        Destroy(gameObject, duration);
    }

    void Update()
    {
        float elapsed = Time.time - startTime;

        if (slider != null)
        {
            slider.value = duration - elapsed;
        }
    }
}
