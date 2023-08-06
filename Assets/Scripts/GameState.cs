using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Global states
    public static int health = 10;
    public static float movementSpeed = 5f;

    // Modifiers
    public int _movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        movementSpeed = _movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
