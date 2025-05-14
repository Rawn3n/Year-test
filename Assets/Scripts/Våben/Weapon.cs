using UnityEngine;
using System.Collections;
using TMPro;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] protected float fireRate = 0.5f;
    [SerializeField] protected float gravity = 0.5f;
    [SerializeField] protected float bulletSpeed = 2f;

    [SerializeField] protected int startammo = 30;
    [SerializeField] protected int currentammo;
    [SerializeField] protected float reloadTime = 10f;
    [SerializeField] private TextMeshProUGUI AmmoText;

    [SerializeField] protected string weaponTag = "";
    [SerializeField] protected Transform firePoint;
    [SerializeField] protected Sprite bulletSprite;

    protected bool isReloading = false;
    protected Coroutine reloadRoutine;
    protected PlayerController playerController;
    private float nextFireTime;

    protected virtual void Start()
    {
        playerController = GetComponentInParent<PlayerController>();
        currentammo = startammo;
    }

    protected virtual void Update()
    {
        RotateTowardsMouse();
        ShowAmmo(currentammo, AmmoText);

        if (isReloading)
        {
            AmmoText.text = "!!";
            return;
        }

        if (Input.GetMouseButton(0) && playerController.canAttack() && Time.time >= nextFireTime && currentammo >= 1)
        {
            nextFireTime = Time.time + fireRate;
            Fire();
        }

        if ((currentammo <= 0 || Input.GetKeyDown(KeyCode.R)) && !isReloading)
        {
            if (reloadRoutine != null)
            {
                StopCoroutine(reloadRoutine);
            }
            reloadRoutine = StartCoroutine(ReloadCoroutine());
        }
    }

    protected void ShowAmmo(int ammo, TextMeshProUGUI text)
    {
        if (text != null)
        {
            text.text = ammo.ToString();
        }
    }

    protected IEnumerator ReloadCoroutine()
    {
        isReloading = true;

        float timer = 0f;
        while (timer < reloadTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }

        currentammo = startammo;
        isReloading = false;
    }

    private void OnDisable()
    {
        if (reloadRoutine != null)
        {
            StopCoroutine(reloadRoutine);
            reloadRoutine = null;
        }
        isReloading = false;
    }

    private void RotateTowardsMouse()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos - transform.position;
        direction.z = 0f;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        bool isPlayerFacingRight = transform.root.localScale.x < 0;
        float flipX = isPlayerFacingRight ? -1f : 1f;
        float flipY = (angle > 90 || angle < -90) ? -1f : 1f;

        transform.localScale = new Vector3(flipX, flipY, 1f);
    }

    protected abstract void Fire();

    protected void SetShooter(GameObject bullet)
    {
        Bullet bulletComponent = bullet.GetComponent<Bullet>();
        if (bulletComponent != null)
        {
            bulletComponent.shooter = playerController.gameObject;
        }
    }
}
