using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireRate = 0.5f;
    [SerializeField] protected float gravity = 0.5f;
    [SerializeField] protected float bulletSpeed = 10f;

    [SerializeField] protected string weapontag = ""; // Husk at lav et tag inden i unity eller virke det ikke

    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Sprite bulletSprite;

    protected PlayerController playerController;
    private float nextFireTime;
    protected virtual void Start()
    {
        playerController = GetComponentInParent<PlayerController>(); // Forvent at våbenet er et child af spilleren
    }
    protected virtual void Update()
    {
        RotateTowardsMouse();

        if (Input.GetMouseButton(0) && playerController.canAttack() && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }
    public void IgnoreShooter(GameObject bullet)
    {
        if (bullet == null || playerController == null) return;

        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent == null) return; // Make sure it has the Bullet script

        bulletComponent.shooter = playerController.gameObject;

        Collider2D bulletCollider = bullet.GetComponent<Collider2D>();
        Collider2D shooterCollider = playerController.GetComponent<Collider2D>();

        if (bulletCollider != null && shooterCollider != null)
        {
            Physics2D.IgnoreCollision(bulletCollider, shooterCollider);
        }
    }
    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        // Calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Check if player is flipped (scale.x < 0)
        bool isPlayerFacingRight = transform.root.localScale.x < 0;

        // Flip gun X scale based on player direction
        float flipX = isPlayerFacingRight ? -1f : 1f;

        // Flip Y to keep weapon upright based on aim angle
        float flipY = (angle > 90 || angle < -90) ? -1f : 1f;

        // Apply flipping
        transform.localScale = new Vector3(flipX, flipY, 1f);
    }
    protected abstract void Fire(); // Skal implementeres i underklasser
}
