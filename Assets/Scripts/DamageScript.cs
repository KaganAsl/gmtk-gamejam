using UnityEngine;

public class DamageScript : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        player = GameObject.Find("Dummy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        PlayerScript playerScript = player.GetComponent<PlayerScript>();
        if (enemy != null)
        {
            playerScript.TakeDamage(enemy.damage);
        }
    }
}
