using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameState : MonoBehaviour
{
    // Global states
    public static int health;
    public static float movementSpeed;

    // Modifiers
    public int _health = 10;
    public float _movementSpeed = 5f;

    // UI Elements
    public TMP_Text statsUI;

    void Start()
    {
        health = _health;
        movementSpeed = _movementSpeed;
    }

    void Update()
    {
        statsUI.text = "Salud: " + health;
    }

    public static void takeDamage() {
        health -= 1;
    }

}
