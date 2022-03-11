using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]

    private float speed = 100f;

    [SerializeField]

    private float jumpForce = 50f;

    private float moveHorizontal = 0;

    private float moveVertical = 0;

    private float accelerate = 0.1f;

    private bool _isGrounded;

    Rigidbody rb;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MovementLogic();
        JumpLogic();
    }

    private void MovementLogic()
    {
        Vector3 moveDirection;

        //Запрет движения, если нажаты кнопки для движения в разные стороны

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            moveVertical = 0;
        }

        //Движение вверх

        else if (Input.GetKey(KeyCode.W))
        {
            if (rb.velocity.z <= speed)
            {
                moveVertical = 1;
            }

            else
            {
                moveVertical = 0;
            }
        }

        //Движение вниз

        else if (Input.GetKey(KeyCode.S))
        {
            if (rb.velocity.z >= speed * -1)
            {
                moveVertical = -1;
            }

            else
            {
                moveVertical = 0;
            }
        }

        else
        {
            moveVertical = 0;
        }

        //Запрет движения, если нажаты кнопки для движения в разные стороны

        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.A))
        {
            moveHorizontal = 0;
        }

        //Движение вправо

        else if (Input.GetKey(KeyCode.D))
        {
            if (rb.velocity.x <= speed)
            {
                moveHorizontal = 1;
            }

            else
            {
                moveHorizontal = 0;
            }
        }

        //Движение влево

        else if (Input.GetKey(KeyCode.A))
        {
            if (rb.velocity.x >= speed * -1)
            {
                moveHorizontal = -1;
            }

            else
            {
                moveHorizontal = 0;
            }
        }

        else
        {
            moveHorizontal = 0;
        }

        moveDirection = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(moveDirection.normalized * speed, ForceMode.Force);

        rb.velocity = rb.velocity - new Vector3(rb.velocity.x * accelerate, 0, rb.velocity.z * accelerate);

        transform.LookAt(transform.position + moveDirection);


    }

    private void JumpLogic()
    {
        if (Input.GetAxis("Jump") > 0)
        {
            if (_isGrounded)
            {
                rb.AddForce(Vector3.up * jumpForce);
            }
        }
    }
    void OnCollisionEnter(Collision collision)
    {
        IsGroundedUpate(collision, true);
    }

    void OnCollisionExit(Collision collision)
    {
        IsGroundedUpate(collision, false);
    }

    private void IsGroundedUpate(Collision collision, bool value)
    {
        if (collision.gameObject.tag == ("Ground"))
        {
            _isGrounded = value;
        }
    }
}

