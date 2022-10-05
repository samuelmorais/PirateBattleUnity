using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    Transform target;
    [SerializeField]
    float speed;

    [SerializeField]
    bool isChaser;

    [SerializeField]
    float chaseRadius = 3f;

    Rigidbody2D body;

    float lastTimeMove = 0;
    float nextTimeRotate = 0;

    float currentRotation = 0;

    const float MIN_ROTATION = 0f;
    const float MAX_ROTATION = 0.3f;

    const float MIN_FORWARD = 0f;
    const float MAX_FORWARD = 10f;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        target = GameObject.Find("PlayerShip").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isChaser) 
            CheckChaseCondition();
        else
            MoveRandomly();
    }
    void CheckChaseCondition() {
        if(Vector2.Distance(transform.position, target.position) < chaseRadius)   {    
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            RotateTowardsPlayerShip();
        }
        else MoveRandomly();
    }

    void MoveRandomly() {
        if(Time.time - lastTimeMove > 0.25f) {
            lastTimeMove = Time.time;   
            MoveForward(Random.Range(MIN_FORWARD, MAX_FORWARD));
        }

        if(Time.time > nextTimeRotate ) {
            if(Time.time > nextTimeRotate + 0.25f) {
                nextTimeRotate = Time.time + Random.Range(1f,2f); 
                currentRotation = Random.Range(MIN_ROTATION, MAX_ROTATION); 
            }
            Rotate(currentRotation);
        }
    }
    private void MoveForward(float ammount) {
        Vector2 force = transform.up * ammount;
        body.AddForce(force); 
    }

    void Rotate(float ammount) {
        transform.Rotate(0, 0, -ammount);
    }

    void RotateTowardsPlayerShip() {
        float angle = Mathf.Atan2(target.position.y, target.position.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void AvoidObstacle() {
        transform.Rotate(0, 0, Random.Range(-90f,-120f));
    }

    public bool IsChaser() {
        return isChaser;
    }
}
