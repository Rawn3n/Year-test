using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    [SerializeField] protected float startHP = 100f;
    protected float currentHP;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHP = startHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHP <= 0f)
        {
            Kill();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            TakeDamage(50);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spike"))
        {
            TakeDamage(50);
        }
    }
    public void TakeDamage(float damage)
    {
        currentHP -= damage;
    }
    void HealHP(float heal)
    {
        currentHP += heal;  
    }
    protected virtual void Kill()
    {
        // Perform actions for player death here, e.g., play death animation, show game over screen, etc.

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        /*
        Respawn the player at the specified respawn point
        transform.position = respawnPoint.position;

        Reset the player's health
        currentHealth = maxHealth;
        UpdateHealthBar();
        */
    }
}
