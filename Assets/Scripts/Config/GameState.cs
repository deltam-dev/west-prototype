using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{
    public static GameState Instance { get; private set; }

    // Global states
    int maxHealth;
    int maxRelics;
    public int health;
    public float movementSpeed;
    public GameObject tl_hud;

    HealthBar hb;
    HUDController hud;
    ArrayList relics;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        maxHealth = 100;
        maxRelics = 10;

        hb = GetComponent<HealthBar>();
        hud = GetComponent<HUDController>();

        relics = new ArrayList();
    }

    void Update()
    {
        
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

    public void addRelic()
    {
        if (relics.Count < maxRelics)
        {
            
            Relic relic = new Relic("Relic " + relics.Count);
            relics.Add(relic);
            GameObject relicGO = hud.addRelic(relics.Count);
            relicGO.GetComponent<RelicController>().setRelicData(relic);
        } 
    }
}
