using Assets.MyProject.Script.Manager;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    [SerializeField] private StageManager stageManager;
    [SerializeField] private BotManager botManager;
    private void Awake()
    {
        if (stageManager == null && botManager == null)
        {
            stageManager = FindFirstObjectByType<StageManager>();
            botManager = FindFirstObjectByType<BotManager>();   
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // GuideBot µµÂø
        BotNavMesh bot = other.GetComponent<BotNavMesh>();
        if (bot != null)
        {
            botManager.BotArrived();
            return;
        }

        // Player µµÂø
        if (!other.CompareTag("Player"))
            return;

        stageManager.NextStage();
    }
}