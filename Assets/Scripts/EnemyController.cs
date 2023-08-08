using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyController : MonoBehaviour
{

    private Transform target;
    private Animator animator;
    public float speed;
    public bool follow;
    public float animDistance;
    public float distance;
    public bool atack;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        var distancia = (target.position - transform.position).magnitude;

        if (follow && distancia>= distance)
        {
            animator.SetBool("isWalking", true);
            SelectAnimation("walk");
            transform.position = Vector2.MoveTowards(transform.position,target.position,speed * Time.deltaTime);
            Debug.Log("position:" + target.position);
        }
        else
        {   
            follow = false;
            if (distancia < distance)
            {
                animator.SetBool("isAtacking", true);
                animator.SetBool("isWalking", false);
                SelectAnimation("atack");
            }
            
        }
    }

    private void SelectAnimation(String animation)
    {
        var distanciaX = Mathf.Abs(target.position.x - transform.position.x);

        if (target.position.y < transform.position.y && distanciaX < animDistance)
        {
            // target down
            animator.SetFloat(animation, 0f);
        }
        else if (target.position.y > transform.position.y && distanciaX < animDistance)
        {
            // target up
            animator.SetFloat(animation, 1f);
        }
        else
        {
            // target side
            animator.SetFloat(animation, 0.5f);

            if (target.position.x < transform.position.x)
            {
                // Left
                GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                // right
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

    }

    //when atack finish it start to follow
    public void StartFollow()
    {
        follow = true;
        animator.SetBool("isAtacking", false);
    }

    //end death animation 
    public void Dead()
    {
        Destroy(this.gameObject);
    }

}
