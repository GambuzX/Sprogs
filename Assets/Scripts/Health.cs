using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Fighter))]
[RequireComponent(typeof(AudioSource))]
public class Health : MonoBehaviour
{

    public AudioClip damageSound;
    private const float MAX_HEALTH = 100f;
    private float health;

    private Fighter frog;
    private Image healthBar;
    private LevelController levelController;
    private AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Fighter>();
        healthBar = GameObject.Find(frog.HealthBarName()).transform.Find("HealthBar").GetComponent<Image>();
        health = 100f;
        UpdateHealthBar();
        levelController = GameObject.FindObjectOfType<LevelController>();
        audioSource = GetComponent<AudioSource>();
    }

    public float GetHealth()
    {
        return health;
    }

    private void UpdateHealth(float hp)
    {
        health += hp;
        if(health > MAX_HEALTH)
        {
            health = MAX_HEALTH;
        }

        UpdateHealthBar();

        if (health <= 0f) {
            levelController.GameOver(this.gameObject.GetComponent<Fighter>());
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health*0.5f/MAX_HEALTH;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        string currFrog = GetComponent<Fighter>().GetType().ToString();

        Projectile projectileComp = collider.GetComponent<Projectile>();
        if (projectileComp != null) {
            if (projectileComp.getOrigin() != currFrog) {
                // enemy projectile
                audioSource.clip = damageSound;
                audioSource.Play();
                UpdateHealth(-projectileComp.getDamage());
                projectileComp.SelfDestruct();
            }
        }

        FrogAttack attackComp = collider.GetComponent<FrogAttack>();
        if(attackComp != null) {
            if (attackComp.getOrigin() != currFrog) {
                audioSource.clip = damageSound;
                audioSource.Play();
                UpdateHealth(-attackComp.damage);
            }
        }
    }
}
