    using System.Linq.Expressions;
    using TMPro;
    using UnityEngine;
    using UnityEngine.SceneManagement;
    using UnityEngine.UI;

    public class Health : MonoBehaviour
    {
        [SerializeField] protected bool isDamageable = false;
        [SerializeField] protected float startHP = 100f;
        protected float currentHP;


        [SerializeField] protected Image healthBar;

        [SerializeField ]protected GameObject floatingTextPrefab;

        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            currentHP = startHP;
        }

        // Update is called once per frame
        void Update()
        {
            if (currentHP <= 0f)
            {
                Kill();
            }

            healthBar.fillAmount = Mathf.Clamp(currentHP / startHP, 0, 1);
        }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Enemy"))
            {
                TakeDamage(50);
            }
            if (collision.collider.CompareTag("Boss"))
            {
                TakeDamage(100);
            }

            if (collision.collider.CompareTag("Spike"))
            {
                TakeDamage(50);
            }

        }
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("NinjaStar"))
            {
                TakeDamage(20);
            }
            if (other.CompareTag("BossBullet"))
            {
                TakeDamage(50);
            }
    }
        public void TakeDamage(float damage)
        {
            if (isDamageable == true)
            {
                currentHP -= damage;
            }
        }
        void HealHP(float heal)
        {
            currentHP += heal;  
        }
        protected virtual void Kill()
        {
            // Perform actions for player death here, e.g., play death animation, show game over screen, etc.

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

            /*
            Respawn the player at the specified respawn point
            transform.position = respawnPoint.position;

            Reset the player's health
            currentHealth = maxHealth;
            UpdateHealthBar();
            */
        }

        protected void ShowFloatingText(float textdisplay)
        {
            var go = Instantiate(floatingTextPrefab, transform.position, Quaternion.identity, transform);
            var textComponent = go.GetComponent<TextMeshPro>();
            if (textComponent != null)
            {
                textComponent.text = textdisplay.ToString();
            }
        }
    }
