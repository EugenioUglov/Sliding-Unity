using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private KeyCode _sprintKey = KeyCode.LeftShift;
    [SerializeField] private Rigidbody _rigidbody;
    
    private float _walkSpeed = 250;
    private float _sprintSpeed = 500;
    private float _floorCheckRayLength = 1.05f;
    private float _horizontalAxis;
    private bool _isSprinting = false;
    private bool _isSprintKeyPressed = false;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        _horizontalAxis = Input.GetAxis("Horizontal");
        _isSprintKeyPressed = Input.GetKey(_sprintKey);
    }

    private void FixedUpdate()
    {
        if (_isSprinting == false)
        {
            Move(_walkSpeed);
        }
        else if (_isSprintKeyPressed && _isSprinting)
        {
            Move(_sprintSpeed);
        }
        else
        {
            _isSprinting = false;
        }       
        
    }

    private void Move(float speed)
    {
        Vector3 velocity = Vector3.right * speed * _horizontalAxis * Time.fixedDeltaTime;
        //_rigidbody.AddForce(velocity, ForceMode.VelocityChange);
        velocity.y = _rigidbody.velocity.y;
        _rigidbody.velocity = velocity;
    }

    public bool IsOnFloor()
    {
        return Physics.Raycast(transform.position + Vector3.up, Vector3.down, _floorCheckRayLength);
    }
}
