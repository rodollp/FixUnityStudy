using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;

    private Vector2 moveInput;

    private PlayerInputActions inputActions;

    private void Awake()
    {
        // GetComponent พฦดิ!!
        inputActions = new PlayerInputActions();

        inputActions.Player.Move.performed += ctx =>
        {
            moveInput = ctx.ReadValue<Vector2>();
        };

        inputActions.Player.Move.canceled += ctx =>
        {
            moveInput = Vector2.zero;
        };
    }

    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    void Update()
    {
        Vector3 dir = new Vector3(moveInput.x, 0, moveInput.y);

        transform.position += dir * speed * Time.deltaTime;
    }
}