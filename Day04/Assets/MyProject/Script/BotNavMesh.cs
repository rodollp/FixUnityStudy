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

    public void HideBot()
    {
        gameObject.SetActive(false);
    }
    public void ResetBot()
    {
        gameObject.SetActive(true);
        agent.isStopped = true;

        agent.Warp(botStartPoint.position);
        transform.rotation = botStartPoint.rotation;

        agent.ResetPath();
        agent.isStopped = true ;
        ResetSpeed();

        StartBot();
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