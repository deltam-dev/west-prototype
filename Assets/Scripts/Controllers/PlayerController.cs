using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;

    // for weapon rotation, also move the pivot point to bottom of weapon
    public GameObject weapon;

    // reference for weapon script in order to fire
    public WeaponController weaponController;

    // reference for weapon script in order to spawn enemies
    public EnemySpawnController enemySpawn;

    //for animator
    public Animator animator;
    public bool rotatePlayer = false;
    public bool rotateWeapon = false;

    Vector2 moveDirection;
    Vector2 mousePosition;
    Vector2 cameraPosition;

    // stats
    float movementSpeed;

    private void Start()
    {
        // 6 = Player Layer
        // 7 = Player Ammo Layer
        // 10 = bullet
        // Ignore collisions of both GameObjects
        Physics2D.IgnoreLayerCollision(6, 7);
        animator = GetComponent<Animator>();

        // Get stats from GameState
        movementSpeed = GameState.Instance.movementSpeed;
    }

    void Update()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        float moveDir = Input.GetAxis("Horizontal");

        if (Input.GetMouseButtonDown(0))
        {
            weaponController.fire();
        }

        if (moveX != 0f || moveY != 0f)
        {
            animator.SetBool("isRunning", true);

            // Voltea el sprite horizontalmente
            if (moveDir < 0f)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                Vector3 currentPos = transform.position;
                currentPos.x -= 0.11f;
                currentPos.y -= 0.18f;
                weapon.transform.position = currentPos;
            }
            else
            {
                GetComponent<SpriteRenderer>().flipX = false;
                Vector3 currentPos = transform.position;
                currentPos.x += 0.11f;
                currentPos.y -= 0.18f;
                weapon.transform.position = currentPos;
            }
        }
        else
        {
            animator.SetBool("isRunning", false);
        }

        moveDirection = new Vector2(moveX, moveY).normalized;

        Vector3 screenPoint = Input.mousePosition;
        screenPoint.z = -Camera.main.transform.position.z;
        mousePosition = Camera.main.ScreenToWorldPoint(screenPoint);

        float distance = Vector2.Distance(rb.position, mousePosition);
        cameraPosition = Vector2.MoveTowards(rb.position, mousePosition, (distance / 3));


        // Restart caracter with R s
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameState.Instance.refillHealth();
            animator.SetBool("isDead", false);
        }

        // instanciar enemigos con T
        if (Input.GetKeyDown(KeyCode.T))
        {
            enemySpawn.spawn();
        }

        // add relic, only for testing
        if (Input.GetKeyDown(KeyCode.Z))
        {
            GameState.Instance.addRelic();
        }
    }

    private void FixedUpdate()
    {
        //if is not dead(mejor si va en el gamestate)
        if (!animator.GetBool("isDead"))
        {
            rb.velocity = new Vector2(moveDirection.x * movementSpeed, moveDirection.y * movementSpeed);
        }
        else
        {
            rb.velocity = Vector2.zero;
        }


        if (rotatePlayer)
        {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            rb.rotation = aimAngle;
        }
        else
        {
            rb.rotation = 0f;
        }

        // Currently working
        if (rotateWeapon)
        {
            Vector2 aimDirection = mousePosition - rb.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
            Quaternion aimRotation = Quaternion.Euler(0f, 0f, aimAngle);
            weapon.transform.rotation = aimRotation;
        }

        // moves the camera
        Camera.main.transform.position = new Vector3(cameraPosition.x, cameraPosition.y, -10);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject.tag == "Enemy")
        {
            animator.SetTrigger("hit");
        }
    }
}
