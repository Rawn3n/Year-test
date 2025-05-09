using UnityEngine;
using System.Collections;

public class BurstRifle : Weapon
{
    public int burstCount = 3;
    public float burstDelay = 0.1f;

    protected override void Fire()
    {
        StartCoroutine(Burst());
    }

    private IEnumerator Burst() 
    {
        for (int i = 0; i < burstCount; i++)
        {
            FireSingleBullet();
            yield return new WaitForSeconds(burstDelay);
        }
    }

    void FireSingleBullet()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;

        Vector2 direction = (mousePos - firePoint.position).normalized;

        GameObject bullet = new GameObject("Bullet");
        bullet.tag = weapontag;

        bullet.transform.position = firePoint.position;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        SpriteRenderer sr = bullet.AddComponent<SpriteRenderer>();
        sr.sprite = bulletSprite;

        CircleCollider2D col = bullet.AddComponent<CircleCollider2D>();
        col.isTrigger = true;

        Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = gravity;
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb.linearVelocity = direction * bulletSpeed;

        bullet.AddComponent<Bullet>();
    }
}
