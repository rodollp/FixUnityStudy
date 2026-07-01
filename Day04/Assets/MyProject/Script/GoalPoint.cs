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
        // GuideBot µµÂø
        BotNavMesh bot = other.GetComponent<BotNavMesh>();
        if (bot != null)
        {
            stageManager.BotArrived();
            return;
        }

        // Player µµÂø
        if (!other.CompareTag("Player"))
            return;

        stageManager.NextStage();
    }
}