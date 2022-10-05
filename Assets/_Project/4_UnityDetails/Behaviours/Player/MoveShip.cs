using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShip : MonoBehaviour
{
    Rigidbody2D body;
    private float move;
    [SerializeField]
    private float moveSpeed = 20f;
    private float rotate;

    [SerializeField]
    private float rotateSpeed = 50f;

    float horizontal, vertical;

    void Start() {
        body = GetComponent<Rigidbody2D>();
    }

    void Update() {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 
        move = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        rotate = Input.GetAxis("Horizontal") * - rotateSpeed * Time.deltaTime;
        MoveForward(vertical);
        Rotate(horizontal);
        LimitSpeed();
    }

    void LimitSpeed() {
        float x = Mathf.Clamp(body.velocity.x, -moveSpeed, moveSpeed);
        float y = Mathf.Clamp(body.velocity.y, -moveSpeed, moveSpeed);
        body.velocity = new Vector2(x, y);
    }

    private void MoveForward(float ammount) {
        Vector2 force = transform.up * ammount;
        body.AddForce(force); 
    }

    void Rotate(float ammount) {
        transform.Rotate(0, 0, -ammount);
    }
}
