using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    //for weapon rotation, also move the pivot point to bottom of weapon
    public GameObject wpn;
    //for animator
    public Animator animator;
    public WeaponController weapon;
    public bool rotatePlayer = false;
    public bool rotateWeapon = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    Vector2 cameraPosition;
    
    private void Start() {
        // 6 = Player Layer
        // 7 = Player Ammo Layer
        // Ignore collisions of both GameObjects
        Physics2D.IgnoreLayerCollision(6, 7);
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float moveDir = Input.GetAxis("Horizontal");

        if(Input.GetMouseButtonDown(0)){
            weapon.fire();
        }

        if (moveX != 0f || moveY != 0f)
        {
            animator.SetBool("isRunning", true);
            // Voltea el sprite horizontalmente
            if(moveDir < 0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                Vector3 currentPos = transform.position;
                currentPos.x -=  0.11f;
                currentPos.y -= 0.18f;
                wpn.transform.position = currentPos;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                Vector3 currentPos = transform.position;
                currentPos.x += 0.11f;
                currentPos.y -= 0.18f;
                wpn.transform.position = currentPos;
            }
            
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;
        
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(screenPoint);

        float distance = Vector2.Distance(rb.position, mousePosition);
        cameraPosition = Vector2.MoveTowards(rb.position, mousePosition, (distance / 3));
    }  

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        if (rotatePlayer) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }  

        // Currently working
        if (rotateWeapon) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion aimRotation = Quaternion.Euler(0f, 0f, aimAngle);
            wpn.transform.rotation = aimRotation;

        } 

        // moves the camera
        Camera.main.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.name.Equals("Hit"))
        {
            animator.SetTrigger("hit");
        }else if (collision.name.Equals("Death"))
        {
            animator.SetTrigger("death");
        }
    }
}
