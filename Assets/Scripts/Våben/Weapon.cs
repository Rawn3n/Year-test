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
        if (Input.GetMouseButton(0) && playerController.canAttack() && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }
    }
    protected abstract void Fire(); // Skal implementeres i underklasser
}