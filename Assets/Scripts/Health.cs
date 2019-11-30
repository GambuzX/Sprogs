using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public Image healthBar;
    private float maxHealth;
    private float health;

    // Start is called before the first frame update
    void Start()
    {
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
        Debug.Log("ola");
        if(health > maxHealth)
        {
            health = maxHealth;
        }

        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        Debug.Log("ola1");
        healthBar.fillAmount = health;
    }
}
