using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireRate = 0.5f;
    [SerializeField] protected float gravity = 0.5f;
    [SerializeField] protected float bulletSpeed = 10f;

    [SerializeField] protected string weaponTag = "";

    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Sprite bulletSprite;

    protected PlayerController playerController;
    private float nextFireTime;

    protected virtual void Start()
    {
        playerController = GetComponentInParent<PlayerController>(); // Expecting the weapon is a child of the player
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

    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        // Calculate angle
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Flip the gun based on player direction
        bool isPlayerFacingRight = transform.root.localScale.x < 0;
        float flipX = isPlayerFacingRight ? -1f : 1f;
        float flipY = (angle > 90 || angle < -90) ? -1f : 1f;

        // Apply flipping
        transform.localScale = new Vector3(flipX, flipY, 1f);
    }

    protected abstract void Fire(); // To be implemented in subclasses

    protected void SetShooter(GameObject bullet)
    {
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.shooter = playerController.gameObject;
        }
    }
}
