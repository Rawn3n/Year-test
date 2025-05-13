using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Health health;
    public GameObject shooter;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        health = GetComponent<Health>();
    }
    void Update()
    {

    }
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == shooter)
            return;


        if (other.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }
        if (other.CompareTag("Enemy"))
        {
            if (gameObject.CompareTag("NinjaStar"))
            {

            }
            else
            {
                Destroy(gameObject);
            }
        }
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
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
}
