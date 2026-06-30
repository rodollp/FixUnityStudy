using UnityEngine;

public class BallRotate : MonoBehaviour
{
    [SerializeField] private float rollSpeed = 300f;

    private Vector3 lastPosition;

    private void Awake()
    {
        lastPosition = transform.position;
    }

    private void LateUpdate()
    {
        Vector3 move = transform.position - lastPosition;
        move.y = 0f;

        // 움직였을 때만 굴러감
        if (move.sqrMagnitude > 0.0001f)
        {
            transform.Rotate(Vector3.right * rollSpeed * Time.deltaTime, Space.Self);
        }

        lastPosition = transform.position;
    }
}