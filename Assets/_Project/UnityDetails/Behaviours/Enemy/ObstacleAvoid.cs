using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoid : MonoBehaviour
{
    [SerializeField]
    EnemyMove ship;

    void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Obstacle") {
            ship.AvoidObstacle();
        }    
    }
}
