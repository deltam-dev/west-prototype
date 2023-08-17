using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private void Start() {
        Physics2D.IgnoreLayerCollision(7,7);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.tag == "Player"||collision.gameObject.tag=="bullet")
        {

        }
        else
        {

            if (collision.gameObject.tag == "Enemy")
            {
                //iniciar la animacion de muerte
                collision.gameObject.GetComponent<Animator>().SetTrigger("isDead");

            }
            Destroy(gameObject);
        }
    }


}
