using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public float speed = 2f;
    private Rigidbody2D rb;
    private bool movingRight = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float direction = movingRight ? 1f : -1f;
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Flip();
        }
    }

    void Flip()
    {
        movingRight = !movingRight;
        transform.eulerAngles = new Vector3(0, movingRight ? 0 : 180, 0);
    }
}

