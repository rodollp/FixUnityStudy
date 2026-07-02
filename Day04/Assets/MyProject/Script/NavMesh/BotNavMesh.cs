using UnityEngine;
using UnityEngine.AI;

public class BotNavMesh : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Transform botStartPoint;

    private NavMeshAgent agent;
    private float defaultSpeed;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;

        StopBot();
    }

    public void StartBot()
    {
        if (target == null) return;
        if (!CheckNavMesh()) return;

        MoveBot();
    }

    public void ResetBot()
    {
        ActiveBot();
        ResetPosition();

        if (!CheckNavMesh()) return;

        StopBot();
        ResetSpeed();
    }

    public void HideBot()
    {
        StopBot();
        gameObject.SetActive(false);
    }

    private void ActiveBot()
    {
        gameObject.SetActive(true);
    }

    private void ResetPosition()
    {
        agent.Warp(botStartPoint.position);
        transform.rotation = botStartPoint.rotation;
    }

    private bool CheckNavMesh()
    {
        if (!agent.isOnNavMesh)
        {
            Debug.LogWarning("Bot이 NavMesh 위에 없습니다.");
            return false;
        }

        return true;
    }

    private void MoveBot()
    {
        agent.isStopped = false;
        agent.ResetPath();
        agent.SetDestination(target.position);
    }

    private void StopBot()
    {
        if (agent == null || !agent.isOnNavMesh) return;

        agent.isStopped = true;
        agent.ResetPath();
    }

    public void SetSpeed(float speed)
    {
        agent.speed = speed;
    }

    public void ResetSpeed()
    {
        agent.speed = defaultSpeed;
    }
}