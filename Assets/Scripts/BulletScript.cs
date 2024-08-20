using UnityEngine;

public class BulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Bullet hit something: " + other.gameObject.name);
        if (!(other.gameObject.name.Equals("Food(Clone)") || other.gameObject.name.Equals("Logic")))
        {
            Destroy(gameObject);
        }
    }
}
