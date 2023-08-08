using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //para llamarlo en player
    public GameObject enemyPrefab;
    public List<Transform> points = new List<Transform>();

    public void spawn()
    {
        //aleatorio
        int randomIndex = Random.Range(0, points.Count);
        Transform randomPoint = points[randomIndex];
        GameObject Enemy = Instantiate(enemyPrefab, randomPoint.position, randomPoint.rotation);
    }
}
