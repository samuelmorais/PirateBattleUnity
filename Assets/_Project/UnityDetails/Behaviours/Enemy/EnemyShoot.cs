using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : Shooter
{
    float nextShootTime = 0;
    bool lateralShot = false;
    const float MIN_DISTANCE_TO_SHOOT = 3f;

    void Update()
    {
        if(Time.time  > nextShootTime) {
            nextShootTime = Time.time + Random.Range(1f,3f);
            Debug.Log($"next shoot time: {nextShootTime}");
            Debug.Log($"time: {Time.time}");
            lateralShot = Random.value > 0.5f;
            var playerShip = GameObject.Find("PlayerShip");
            if(Vector3.Distance(playerShip.transform.position, transform.position) < MIN_DISTANCE_TO_SHOOT
             && !GetComponent<EnemyMove>().IsChaser()) {
                if(lateralShot) ShootLateral();
                else ShootFrontal();  
            } 
        }             
    }
}
