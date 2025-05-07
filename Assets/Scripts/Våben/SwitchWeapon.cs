using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public Weapon[] weapons; // Liste over alle våben (sættes i Inspector)
    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // Start med første våben
    }

    void Update()
    {
        // Tryk 1 for våben 1, 2 for våben 2, osv.
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToWeapon(0);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToWeapon(1);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchToWeapon(2);
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToWeapon(3);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToWeapon(4);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchToWeapon(5);
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToWeapon(6);
        if (Input.GetKeyDown(KeyCode.Alpha2)) SwitchToWeapon(7);
        if (Input.GetKeyDown(KeyCode.Alpha3)) SwitchToWeapon(8);
        if (Input.GetKeyDown(KeyCode.Alpha1)) SwitchToWeapon(9);
    }

    void SwitchToWeapon(int index)
    {
        if (index >= weapons.Length || index < 0) return; // Undgå fejl

        // Deaktiver nuværende våben
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // Aktiver det nye våben
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    void EquipWeapon(int index)
    {
        // Slå alle våben fra, bortset fra det valgte
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }
    }
}
