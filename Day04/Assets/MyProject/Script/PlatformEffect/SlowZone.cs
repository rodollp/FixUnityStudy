using UnityEngine;
using UnityEngine.AI;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private float slowSpeed = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.SetMoveSpeed(slowSpeed);
            return;
        }

        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = slowSpeed;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.ResetMoveSpeed();
            return;
        }

        NavMeshAgent agent = other.GetComponent<NavMeshAgent>();
        if (agent != null)
        {
            agent.speed = 3.5f; // 원래 안내 NPC 속도
        }
    }
}