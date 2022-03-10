using UnityEngine;

public class ControllerSimpleMove : MonoBehaviour
{
    public float Speed = 0.0f;
    public float rotSpeed = 0.0f;

    private Vector3 moveDirection;
    private CharacterController _char = null;

    private void Start()
    {
        _char = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if(Input.GetAxis("Vertical") > 0.0f)
        {
            moveDirection = transform.forward * Speed;
        }else if(Input.GetAxis("Vertical") < 0.0f)
        {
            moveDirection = -transform.forward * Speed;
        }else
        {
            moveDirection = Vector3.zero;
        }
        transform.Rotate(new Vector3(0.0f, Input.GetAxis("Horizontal") * rotSpeed, 0.0f));
        _char.SimpleMove(moveDirection);
    }
}
