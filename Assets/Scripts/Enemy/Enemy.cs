using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float health;
    private float maxHP;
    public Slider healthBar;

    void Start() {
        maxHP = health;
        healthBar.maxValue = maxHP;
    }

    void Update()
    {
        if(health <= 0) {
            Destroy(gameObject);
        }

        healthBar.value = health;
    }

    public void TakeDamage(float damage) {
        health -= damage;
    }
}
