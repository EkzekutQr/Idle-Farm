using UnityEngine;

public class ControllerMove : MonoBehaviour
{
    public float Speed = 0.0f;
    public float JumpSpeed = 0.0f;
    public float Gravity = 0.0f;

    private Vector3 moveDirection;
    private CharacterController _char = null;

    private void Start()
    {
        _char = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(_char.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical")) * Speed;
            moveDirection = transform.TransformDirection(moveDirection);
            if(Input.GetKey(KeyCode.Space))
            {
                moveDirection.y += JumpSpeed;
            }
        }else
        {
            moveDirection.y -= Gravity * Time.deltaTime;
        }
        _char.Move(moveDirection * Time.deltaTime);
    }
}
