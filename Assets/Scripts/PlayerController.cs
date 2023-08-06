using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public WeaponController weapon;
    public bool rotatePlayer = false;
    public bool rotateWeapon = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    Vector2 cameraPosition;

    float movementSpeed = 5f;
    
    private void Start() {
        // 6 = Player Layer
        // 7 = Player Ammo Layer
        // Ignore collisions of both GameObjects
        Physics2D.IgnoreLayerCollision(6, 7);

        movementSpeed = GameState.movementSpeed;
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

        float distance = Vector2.Distance(rb.position, mousePosition);
        cameraPosition = Vector2.MoveTowards(rb.position, mousePosition, (distance / 3));
    }  

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        
        if (rotatePlayer) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }  

        // Currently not working, wanna try to move only weapon and not player
        if (rotateWeapon) {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            weapon.GetComponent<Transform>().rotation = new Quaternion(aimAngle, 0, 0, 0);
        } 

        // moves the camera
        Camera.main.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10); 
    }    
}
