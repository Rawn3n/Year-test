using Unity.VisualScripting;
using UnityEngine;

public class BossDrop : MonoBehaviour
{
    protected SwitchWeapon sW;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sW = GetComponent<SwitchWeapon>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            sW.UnlockWeapon(1);
        }
    }
}
