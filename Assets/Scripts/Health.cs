﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Fighter))]
public class Health : MonoBehaviour
{
    private const float MAX_HEALTH = 100f;
    private float health;

    private Fighter frog;
    private Image healthBar;

    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Fighter>();
        healthBar = GameObject.Find(frog.HealthBarName()).transform.Find("HealthBar").GetComponent<Image>();
        health = 100f;
        UpdateHealthBar();
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
            LevelController.GameOver(this.gameObject.GetComponent<Fighter>());
        }
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health*0.5f/MAX_HEALTH;
    }

    void OnTriggerEnter2D(Collider2D collider) {
        Projectile projectileComp = collider.GetComponent<Projectile>();
        if (projectileComp != null) {
            if (projectileComp.getOrigin() != GetComponent<Fighter>().GetType().ToString()) {
                // enemy projectile
                UpdateHealth(-projectileComp.getDamage());
                projectileComp.SelfDestruct();
            }
        }
    }
}
