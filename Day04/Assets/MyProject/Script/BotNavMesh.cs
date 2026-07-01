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
        agent.isStopped = true;
    }

    public void StartBot()
    {
        if (target == null) return;

        agent.isStopped = false;
        agent.SetDestination(target.position);
    }

    public void ResetBot()
    {
        agent.isStopped = true;
        agent.ResetPath();

        transform.position = botStartPoint.position;
        transform.rotation = botStartPoint.rotation;

        ResetSpeed();
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