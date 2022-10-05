using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float speed = 50f;
    [SerializeField]
    float deactivateTimeout = 5f;

    Rigidbody2D body;
    int direction = 0;
    bool launched = false;

    int shooterId = 0;

    void Start() {
        Invoke("DeactivateGameObejct", deactivateTimeout);
        body = GetComponent<Rigidbody2D>();
    }

    public void SetDirection(int direction) {
        this.direction = direction;
        launched = true;
    }

    void Update() {
        Move();
    }

    void Move() {
        if(!launched) return;
        if(direction == 1)
            body.velocity = transform.right * speed;
        else if(direction == -1)
            body.velocity = transform.right * -1 * speed;
        else 
            body.velocity = transform.up * speed;
    }

    void DeactivateGameObejct() {
        gameObject.SetActive(false);
    }

    public void SetShooterID(int shooterId) {
        this.shooterId = shooterId;
    }

    public int GetShooterID() {
        return shooterId;
    }
}
