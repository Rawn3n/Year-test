using UnityEngine;

public class Glock : Weapon
{
    protected override void Fire()
    {
        // Få musens position i verdenskoordinater
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f; // Vi sætter Z til 0, da vi arbejder i 2D

        // Beregn retningen fra våbnets "firePoint" til musen og normaliser vektoren
        Vector2 direction = (mousePos - firePoint.position).normalized;

        // Opret et nyt GameObject, der skal være selve kuglen
        GameObject bullet = new GameObject("Bullet");
        bullet.tag = weaponTag;

        // Sæt kuglens startposition til firePoint
        bullet.transform.position = firePoint.position;

        //Drej kuglen mod rigtigte retning
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

        // Tilføj en SpriteRenderer, så vi kan se kuglen
        SpriteRenderer sr = bullet.AddComponent<SpriteRenderer>();
        sr.sprite = bulletSprite;         // Brug den sprite, der er sat i Inspector
        //sr.color = Color.yellow;          // Gør kuglen gul for synlighed

        // Tilføj en Collider, så kuglen kan kollidere med andre objekter
        CircleCollider2D col = bullet.AddComponent<CircleCollider2D>();
        col.isTrigger = true; // Trigger = den kolliderer uden at skubbe på andre objekter

        // Tilføj Rigidbody2D for at kunne bevæge kuglen med fysik
        Rigidbody2D rb = bullet.AddComponent<Rigidbody2D>();
        rb.gravityScale = gravity; // Gør at kuglen kan falde (valgfrit)
        rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous; // Undgår at kuglen går igennem ting
        rb.linearVelocity = direction * bulletSpeed; // Giv kuglen fart i den retning, spilleren skyder

        // Tilføj Bullet-script, hvis du vil give kuglen yderligere funktion (fx skade)
        bullet.AddComponent<Bullet>();

        SetShooter(bullet); // kald vores funktion så den ikke rammer ham der skyder den
    }
}
