using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
     [SerializeField]
     Transform[] spawnPoints;

     [SerializeField]
     GameObject[] enemyPrefabs;

     [SerializeField]
     GameObject healthTextPrefab;

      private float nextSpawnTime = 0.0f;
      public float period = 0.1f;
      
      void Update () {
         if(Time.time  > nextSpawnTime) {
            nextSpawnTime = Time.time + Random.Range(3f,6f);
            SpawnNewEnemy(); 
        }  
      }

     void Start() {

     }

     void SpawnNewEnemy() {
        int randEnemy = Random.Range(0, enemyPrefabs.Length);
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        var newEnemy = Instantiate(enemyPrefabs[randEnemy], spawnPoints[randSpawnPoint].position, transform.rotation);
        var textHealthEnemy = Instantiate(healthTextPrefab, transform.position, Quaternion.identity);
        textHealthEnemy.transform.parent = GameObject.Find("UI").transform;
        newEnemy.GetComponent<HealthUIEnemy>().SetTextTransform(textHealthEnemy.transform);
     }
}
