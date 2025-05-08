using UnityEngine;

public class EnemyPatrol2 : EnemyPatrol
{
    [SerializeField] private float flyforceup = 0.5f;
    [SerializeField] private float flydelay = 2f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected override void Start()
    {
        base.Start();
        InvokeRepeating(nameof(ApplyFlyForce), 0f, flydelay);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Wall"))
        {
            Flip();
        }

    }
    protected override void FixedUpdate()
    {
        // Flying enemy does not need base walking movement
    }
    void Fly(float movingdirection)
    {
        Vector2 flyForce = new Vector2(movingdirection, flyforceup);
        rb.AddForce(flyForce, ForceMode2D.Impulse);
    }
    void ApplyFlyForce()
    {
        float direction = movingRight ? 1f : -1f;
        Fly(direction);
    }
}
