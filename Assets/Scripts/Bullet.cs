using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player") {
            
        } else {
            Destroy(gameObject);
        }
    }                                                                                                                                                                                                                                                                                                                                                                                                                                                                            
}
