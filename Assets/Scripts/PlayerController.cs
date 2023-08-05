using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public WeaponController weapon;
    public bool rotatePlayer = false;
    public bool rotateWeapon = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    
    private void Start() {
        Physics2D.IgnoreLayerCollision(6, 7);
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if(Input.GetMouseButtonDown(0)){
            weapon.fire();
        }        

        moveDirection = new Vector2(moveX, moveY).normalized;
        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = - Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(screenPoint);
    }  

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
        
        if (rotatePlayer) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }  

        if (rotateWeapon) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            weapon.GetComponent<Transform>().rotation = new Quaternion(aimAngle, 0, 0, 0);
        }  
    }    
}
