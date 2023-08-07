using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    // Global states
    public static int health;
    public static float movementSpeed;

    // Modifiers
    public int _health = 10;
    public float _movementSpeed = 5f;

    void Start()
    {
        health = _health;
        movementSpeed = _movementSpeed;
    }

    public static void takeDamage() {
        health -= 1;
    }

}
