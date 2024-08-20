using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float bulletDamage;
    public float bulletShrinkPower;
    void Start()
    {
        bulletDamage = 20f;
        bulletShrinkPower = 0.01f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!(other.gameObject.name.Equals("Food(Clone)") || other.gameObject.name.Equals("Logic")))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<EnemyScript>() != null)
        {
            other.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
    }
}
