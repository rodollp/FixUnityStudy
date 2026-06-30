using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private PlayerInputHandle input;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    private float firstSpeed;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Transform ballVisual;
    [SerializeField] private float rollSpeed = 300f;
    [SerializeField] private float checkGround = 0.1f;

    Rigidbody rb;
    bool isGround;

    private void Awake()
    {
        if(input ==  null) input = GetComponent<PlayerInputHandle>();
        if (rb == null) rb = GetComponent<Rigidbody>();

        firstSpeed = moveSpeed;
    }

    private void Update()
    {
        if (input.jumpPressed)
        {
            Jump();
        }
        
    }
    private void FixedUpdate()
    {
        Move();
        
    }


    void Move()
    {
        Vector2 inputMove = input.moveInput;
        Vector3 move = new Vector3(inputMove.x,0,inputMove.y);

        

        rb.MovePosition(rb.position + move * moveSpeed * Time.fixedDeltaTime);

        if (move.sqrMagnitude > 0.01f)
        { 
            Quaternion targetRotation = Quaternion.LookRotation(move);
            ballVisual.rotation = Quaternion.Slerp(ballVisual.rotation, targetRotation, rollSpeed*Time.fixedDeltaTime);
        }
    }

    void Jump()
    {
        if(CheckGround())
        {
            rb.AddForce(Vector3.up*jumpForce,ForceMode.Impulse);
        }
    }

    bool CheckGround()
    {
        isGround = Physics.Raycast(groundCheck.position, Vector3.down, checkGround,Physics.DefaultRaycastLayers,QueryTriggerInteraction.Ignore);
        return isGround;
    }

    public void SetMoveSpeed(float speed)
    {
        moveSpeed = speed;
    }
    public void ResetMoveSpeed()
    {
        moveSpeed = firstSpeed;
    }
}
