using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject shooter;

    void Start()
    {
        // Ignore collision with the shooter
        if (shooter != null)
        {
            Collider2D bulletCollider = GetComponent<Collider2D>();
            Collider2D shooterCollider = shooter.GetComponent<Collider2D>();
            if (bulletCollider != null && shooterCollider != null)
            {
                Physics2D.IgnoreCollision(bulletCollider, shooterCollider);
            }
        }
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Don't hit the shooter
        if (other.gameObject == shooter) return;

        // Optional: check if it's something that should stop the bullet
        if (other.gameObject.layer == LayerMask.NameToLayer("Ground") ||
            other.CompareTag("Enemy") ||
            other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.collider.CompareTag("Player"))
    //    {
    //        Destroy(gameObject);
    //    }
    //    if (collision.collider.CompareTag("Enemy"))
    //    {
    //        Destroy(gameObject);
    //    }
    //}
