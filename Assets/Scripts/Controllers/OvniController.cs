using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class OvniController : MonoBehaviour
{

    private Transform player;
    private bool yetFollowToEnemy = false;
    GameObject enemyTarget = null;
    RaycastHit2D raycastHit2D;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        Physics2D.IgnoreLayerCollision(10, 6);


    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        raycastHit2D = Physics2D.Raycast(transform.position, Vector2.down, 4f);
        Debug.DrawRay(transform.position, Vector2.down * 4f, Color.green);

        if (!yetFollowToEnemy)
        {


            foreach (GameObject enemy in enemies)
            {
                float distanceToEnemy = (enemy.transform.position - transform.position).magnitude;
                if (distanceToEnemy < 5f)
                {
                    enemyTarget = enemy;
                    yetFollowToEnemy = true;
                    break;
                }
            }
        }

        if (enemyTarget != null && yetFollowToEnemy)
        {
            Vector3 positionToStay = new Vector3(enemyTarget.transform.position.x, enemyTarget.transform.position.y + 1);
            transform.position = Vector2.MoveTowards(transform.position, positionToStay, 2.5f * Time.deltaTime);
        }

        bool colliderWithEnemy = raycastHit2D.collider != null && raycastHit2D.collider.tag == "Enemy";

        if (enemyTarget != null && yetFollowToEnemy && colliderWithEnemy)
        {
            raycastHit2D.collider.GetComponent<EnemyController>().Dead();
            yetFollowToEnemy = false;
        }

        float distanceToPlayer = (player.position - transform.position).magnitude;
        if (distanceToPlayer >= 0f && !yetFollowToEnemy)
        {
            Vector3 positionToStay = new Vector3(player.position.x, player.position.y + 1);
            transform.position = Vector2.MoveTowards(transform.position, positionToStay, 2.5f * Time.deltaTime);
        }

    }
}
