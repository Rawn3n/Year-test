using UnityEngine;

public class BoxBreak : MonoBehaviour
{
    public int health = 3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("NinjaStar") || (other.CompareTag("BossBullet") || (other.CompareTag("Rifle") || (other.CompareTag("BurstRifle") || (other.CompareTag("Glock"))))))
        {
            health -= 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Enemy"))
        {
            health -= 3;
        }
    }
}
