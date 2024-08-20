using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    private Vector2 movement;
    private float scaleX;
    private float scaleY;
    public float health = 100f;
    public float exp = 0f;
    public Image healthBar;
    public Image expBar;
    public GameObject logic;
    public ShootingScript shootingScript;

    void Start()
    {
        rb.GetComponent<Rigidbody2D>();
        scaleX = transform.localScale.x;
        scaleY = transform.localScale.y;
        expBar.fillAmount = 0;
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        RotateTowardsMouse();
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        expBar.fillAmount = exp / 100f;
    }

    void FixedUpdate()
    {
         rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        FoodScript food = other.GetComponent<FoodScript>();
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        if (food != null)
        {
            EatFood(food.foodScaleValue, food.foodValue);
            Destroy(other.gameObject);
        }
        if (enemy != null)
        {
            TakeDamage(enemy.damage);
        }
    }

    void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = (mousePos - transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        angle -= 90f;

        rb.rotation = angle;
    }

    void EatFood(float foodScaleValue, float foodValue)
    {
        if (scaleX < 4)
        {
            scaleX += foodScaleValue;
            scaleY += foodScaleValue;
            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
        }
        if (health < 100)
        {
            health += foodValue;
            healthBar.fillAmount = health / 100f;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        healthBar.fillAmount = health / 100f;
        if (health <= 0)
        {
            Destroy(gameObject);
            Application.Quit();
        }
    }

    public void IncrementExp(float expValue)
    {
        if (exp < 100)
        {
            exp += expValue;
            if (exp > 100)
            {
                exp = 100;
            }
        }
    }

    void Shoot()
    {
        if (scaleX >= 1)
        {
            shootingScript.Shoot();
            scaleX -= shootingScript.bulletPrefab.GetComponent<BulletScript>().bulletShrinkPower;
            scaleY -= shootingScript.bulletPrefab.GetComponent<BulletScript>().bulletShrinkPower;
            transform.localScale = new Vector3(scaleX, scaleY, transform.localScale.z);
        }
    }
}
