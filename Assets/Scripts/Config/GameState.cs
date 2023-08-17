using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameState : MonoBehaviour
{

    public bool canShoot = true;  // Indica si el jugador puede disparar
    public float timeSinceLastShot;  // Tiempo desde el último disparo
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

    FireRatioBar fireRatioBar;

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
        fireRatioBar = GetComponent<FireRatioBar>();
        relics = new ArrayList();
    }

    void Update()
    {

    }

    public FireRatioBar GetFireRatioBar()
    {
        return fireRatioBar;
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
