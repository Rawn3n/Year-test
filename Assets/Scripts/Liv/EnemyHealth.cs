using UnityEngine;

public class EnemyHealth : Health
{
    private float glockDamage = 3;
    private float Riflekamage = 5;
    private float burstDamage = 10;
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
            TakeDamage(glockDamage);
            if (floatingTextPrefab != null)
            {
                ShowFloatingText(glockDamage);
            }
        }
    }
    protected override void Kill()
    {
        Destroy(gameObject);
    }
}
