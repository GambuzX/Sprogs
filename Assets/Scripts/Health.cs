using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Fighter))]
public class Health : MonoBehaviour
{
    public Image healthBar;
    private float maxHealth;
    private float health;

    private Fighter frog;

    // Start is called before the first frame update
    void Start()
    {
        frog = GetComponent<Fighter>();
        healthBar = GameObject.Find(frog.HealthBarName()).GetComponent<Image>();
        maxHealth = 0.5f;
        health = 0.5f;
        UpdateHealthBar();
    }

    public float GetHealth()
    {
        return health;
    }

    public void UpdateHealth(float hp)
    {
        health += hp;
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        healthBar.fillAmount = health;
    }
}
