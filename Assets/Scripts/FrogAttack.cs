using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrogAttack : MonoBehaviour
{

    public float damage;

    private string origin;

    void Start() {
        this.origin = GetComponentInParent<Fighter>().GetType().ToString();
    }

    public void setDamage(float damage) {
        this.damage = damage;
    }

    public string getOrigin() {
        return origin;
    }
}
