using UnityEngine;
using UnityEngine.AI;

public class BotNavMesh : MonoBehaviour
{
    [SerializeField] private Transform target;
    private float defaultSpeed;

    private NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed;
    }

    private void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }

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
