using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoystickController : MonoBehaviour
{
    [SerializeField]
    private float speed = 100f;

    private float accelerate = 0.1f;

    private Rigidbody rb;

    [SerializeField]
    private Joystick joystick;

    [SerializeField]
    AnimatorManager animatorManager;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
    }

    private void MovementLogic()
    {
        if (joystick.IsShow)
        {
            Vector3 moveDirection;

            moveDirection.x = joystick.direction.x;
            moveDirection.z = joystick.direction.y;
            moveDirection.y = 0;

            rb.AddForce(moveDirection * speed, ForceMode.Force);

            rb.velocity = rb.velocity - new Vector3(rb.velocity.x * accelerate, 0, rb.velocity.z * accelerate);

            transform.LookAt(transform.position + moveDirection);

            animatorManager.isMoving = true;
        }
        else
        {
            animatorManager.isMoving = false;
        }
    }
}
