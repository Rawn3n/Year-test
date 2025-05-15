using UnityEngine;

public class SwitchWeapon : MonoBehaviour
{
    public Weapon[] weapons;
    private Weapon[] unlockedWeapons;
    private int currentWeaponIndex = -1;

    void Start()
    {
        unlockedWeapons = new Weapon[weapons.Length];

        foreach (var weapon in weapons)
        {
            if (weapon != null)
                weapon.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("weapon_0", 0) == 0)
        {
            PlayerPrefs.SetInt("weapon_0", 1);
            PlayerPrefs.Save();
        }

        for (int i = 0; i < weapons.Length; i++)
        {
            if (PlayerPrefs.GetInt("weapon_" + i, 0) == 1)
            {
                UnlockWeapon(i);

                if (currentWeaponIndex == -1)
                {
                    currentWeaponIndex = i;
                }
            }
        }

        if (currentWeaponIndex != -1)
        {
            EquipWeapon(currentWeaponIndex);
        }
        else
        {
            Debug.LogWarning("No weapons unlocked!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) { SwitchToWeapon(0); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { SwitchToWeapon(1); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { SwitchToWeapon(2); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { SwitchToWeapon(3); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { SwitchToWeapon(4); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { SwitchToWeapon(5); }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { SwitchToWeapon(6); }
    }

    void SwitchToWeapon(int index)
    {
        if (index < 0 || index >= unlockedWeapons.Length || unlockedWeapons[index] == null)
        {
            Debug.LogWarning("Invalid weapon index or weapon not unlocked: " + index);
            return;
        }

        if (unlockedWeapons[currentWeaponIndex] != null)
        {
            unlockedWeapons[currentWeaponIndex].gameObject.SetActive(false);
        }

        currentWeaponIndex = index;
        unlockedWeapons[currentWeaponIndex].gameObject.SetActive(true);
    }

    void EquipWeapon(int index)
    {
        for (int i = 0; i < unlockedWeapons.Length; i++)
        {
            if (unlockedWeapons[i] != null)
            {
                unlockedWeapons[i].gameObject.SetActive(i == index);
            }
        }
    }

    void UnlockWeapon(int index)
    {
        if (index >= 0 && index < weapons.Length && weapons[index] != null)
        {
            unlockedWeapons[index] = weapons[index];
            PlayerPrefs.SetInt("weapon_" + index, 1);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.LogWarning("Attempting to unlock an invalid weapon index or null weapon: " + index);
        }
    }
}
