using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    private Animator animator;
    public float speed;
    public bool follow;
    public float animDistance;

    public float atack;

    //bool 
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (follow)
        {
            animator.SetBool("isWalking", true);
            SelectAnimation();
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            Debug.Log("position:" + target.position);
        }
    }

    private void SelectAnimation()
    {
        var distanciaX = Mathf.Abs(target.position.x - transform.position.x);

        if (target.position.y < transform.position.y && distanciaX < animDistance)
        {
            // El objetivo está debajo
            animator.SetFloat("walk", 0f);
        }
        else if (target.position.y > transform.position.y && distanciaX < animDistance)
        {
            // El objetivo está encima
            animator.SetFloat("walk", 1f);
        }
        else
        {
            // El objetivo está en la misma altura que el personaje
            animator.SetFloat("walk", 0.5f);

            if (target.position.x < transform.position.x)
            {
                // El objetivo está a la izquierda
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                // El objetivo está a la derecha
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }

    private void StartFollow()
    {
        follow = true;
    }
}
