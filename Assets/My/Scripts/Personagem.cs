using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personagem : MonoBehaviour
{
    public Joystick joystick;
    public JoyButton button;

    private Rigidbody rb;
    public float moveH, moveV, speedMove = 5;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();

    }
    void MovePlayer() {
        moveH = joystick.Horizontal;
        moveV = joystick.Vertical;
        Vector3 dir = new Vector3(moveH, 0, moveV);
        rb.velocity = new Vector3(moveH * speedMove, rb.velocity.y, moveV * speedMove);
        if (dir != Vector3.zero) {
            transform.LookAt(transform.position + dir);
        }
    }
}
