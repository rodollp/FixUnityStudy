using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private StageManager stageManager;

    private void Awake()
    {
        if (stageManager == null)
        {
            stageManager = FindFirstObjectByType<StageManager>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (!other.CompareTag("Player"))
        { 
            return;
        }
            stageManager.NextStage();
    }
}
