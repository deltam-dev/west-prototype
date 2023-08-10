using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }
    
    // Global states
    public int maxHealth;
    public int health;
    public float movementSpeed;

    HealthBar hb;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        hb = GetComponent<HealthBar>();    
    }

    public void takeDamage()
    {
        health -= 10;
        hb.setHealth(health);
    }

    // Restart life
    public void refillHealth()
    {
        health = maxHealth;
    }
}
