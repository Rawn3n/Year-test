using UnityEngine;

public class EnemyHealth : Health
{
    [SerializeField] private float glockDamage = 3f;
    [SerializeField] private float rifleDamage = 5f;
    [SerializeField] private float burstDamage = 7f;
    [SerializeField] private float boxDamage = 50f;

    [SerializeField] private GameObject bossHealthBarList;
    public GameObject bossDrop;
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
        healthBar.fillAmount = Mathf.Clamp(currentHP / startHP, 0, 1);
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
        if (other.CompareTag("Rifle"))
        {
            TakeDamage(rifleDamage);
            if (floatingTextPrefab != null)
            {
                ShowFloatingText(rifleDamage);
            }
        }
        if (other.CompareTag("BurstRifle"))
        {
            TakeDamage(burstDamage);
            if (floatingTextPrefab != null)
            {
                ShowFloatingText(burstDamage);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Box"))
        {
            TakeDamage(boxDamage);
            if (floatingTextPrefab != null)
            {
                ShowFloatingText(boxDamage);
            }
        }
    }
    protected override void Kill()
    {
        Destroy(gameObject);
        if (bossHealthBarList != null)
        {
            Destroy(bossHealthBarList);
        }
        if (CompareTag("Boss"))
        {
            Instantiate(bossDrop, transform.position, Quaternion.identity);
        }
    }
}
