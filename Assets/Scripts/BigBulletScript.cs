using UnityEngine;

public class BigBulletScript : MonoBehaviour
{
    public float bulletDamage;
    public float bulletShrinkPower;
    void Start()
    {
        bulletDamage = 90f;
        bulletShrinkPower = 0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name.Contains("Wall"))
        {
            Destroy(gameObject);
        }
        if (other.gameObject.GetComponent<EnemyScript>() != null)
        {
            other.gameObject.GetComponent<EnemyScript>().TakeDamage(bulletDamage);
        }
    }
}
