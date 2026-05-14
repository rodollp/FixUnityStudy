using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerControl : MonoBehaviour
{
    public InputAction moveAction;
    public float speed = 5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        moveAction.Enable();
    }

    void FixedUpdate()
    {
        Vector2 input = moveAction.ReadValue<Vector2>();

        // X,Z 이동
        Vector3 move = new Vector3(input.x, 0, input.y);

        // 현재 위치 + 이동값
        Vector3 nextPos = rb.position + move * speed * Time.fixedDeltaTime;

        // Rigidbody 이동
        rb.MovePosition(nextPos);
    }
}
