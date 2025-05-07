using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public Weapon[] weapons; // Liste over alle v�ben (s�ttes i Inspector)
    private int currentWeaponIndex = 0;

    void Start()
    {
        EquipWeapon(currentWeaponIndex); // Start med f�rste v�ben
    }

    void Update()
    {
        // Tryk 1 for v�ben 1, 2 for v�ben 2, osv.
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
        if (index >= weapons.Length || index < 0) return; // Undg� fejl

        // Deaktiver nuv�rende v�ben
        weapons[currentWeaponIndex].gameObject.SetActive(false);

        // Aktiver det nye v�ben
        currentWeaponIndex = index;
        weapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    void EquipWeapon(int index)
    {
        // Sl� alle v�ben fra, bortset fra det valgte
        for (int i = 0; i < weapons.Length; i++)
        {
            weapons[i].gameObject.SetActive(i == index);
        }
    }
}
