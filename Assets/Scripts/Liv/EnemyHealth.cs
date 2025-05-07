using UnityEngine;

public class EnemyHealth : Health
{
    void Start()
    {
        currentHP = startHP;
    }

    void Update()
    {
        if (currentHP <= 0f)
        {
            Kill();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Glock"))
        {
            TakeDamage(100);
        }
    }
    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
