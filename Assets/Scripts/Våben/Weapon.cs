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
    private void RotateTowardsMouse()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Drej våbenet mod musen
        transform.rotation = Quaternion.Euler(0, 0, angle);

        // Flip i Y-aksen hvis vinklen er uden for -90 til 90 grader (dvs. peger mod venstre)
        if (angle > 90 || angle < -90)
        {
            transform.localScale = new Vector3(1, -1, 1);
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    protected abstract void Fire(); // Skal implementeres i underklasser
}