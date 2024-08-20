using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    public float health;
    public Slider healthBar;
    public GameObject target;
    public float damage;
    void Start()
    {
        healthBar = GetComponentInChildren<Slider>();
        healthBar.maxValue = health;
        if (target == null)
        {
            target = GameObject.Find("Dummy");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }

        if (target != null)
        {
            Vector3 direction = (target.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }

        healthBar.value = health;
    }
}
