using UnityEngine;

public class Glock : Weapon
{
    protected override void Fire()
    {
        // F� musens position i verdenskoordinater
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Vi s�tter Z til 0, da vi arbejder i 2D

        // Beregn retningen fra v�bnets "firePoint" til musen og normaliser vektoren
        Vector2 direction = (mousePos - firePoint.position).normalized;

        // Opret et nyt GameObject, der skal v�re selve kuglen
        GameObject bullet = new GameObject("Bullet");
        bullet.tag = weaponTag;

        // S�t kuglens startposition til firePoint
        bullet.transform.position = firePoint.position;

        //Drej kuglen mod rigtigte retning
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Tilf�j en SpriteRenderer, s� vi kan se kuglen
        SpriteRenderer sr = bullet.AddComponent<SpriteRenderer>();
        sr.sprite = bulletSprite;         // Brug den sprite, der er sat i Inspector
        //sr.color = Color.yellow;          // G�r kuglen gul for synlighed

        // Tilf�j en Collider, s� kuglen kan kollidere med andre objekter
        CircleCollider2D col = bullet.AddComponent<CircleCollider2D>();
        col.isTrigger = true; // Trigger = den kolliderer uden at skubbe p� andre objekter

        // Tilf�j Rigidbody2D for at kunne bev�ge kuglen med fysik
        Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = gravity; // G�r at kuglen kan falde (valgfrit)
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Undg�r at kuglen g�r igennem ting
        rb.linearVelocity = direction * bulletSpeed; // Giv kuglen fart i den retning, spilleren skyder

        // Tilf�j Bullet-script, hvis du vil give kuglen yderligere funktion (fx skade)
        bullet.AddComponent<Bullet>();

        SetShooter(bullet); // kald vores funktion s� den ikke rammer ham der skyder den
    }
}
