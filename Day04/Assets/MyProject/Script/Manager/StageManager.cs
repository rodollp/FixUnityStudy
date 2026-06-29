using UnityEngine;

public class StageManager : MonoBehaviour
{

    [SerializeField] private RespawnManager respawnManager;
    [SerializeField] private UIManager uiManager;
    [Header("현재 스테이지")]
    [SerializeField] private StageData[] stages;

    private int currentStageIndex;

    [Header("현재 획득한 포인트")]
    [SerializeField] private int currentPoint;

    StageData CurrentStage => stages[currentStageIndex];
    private int needPoint;

    private void Start()
    {
        currentStageIndex = 0;
        StartStage();
    }

    void StartStage()
    {
        
        // 모든 스테이지 끄기
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].stageRoot.SetActive(false);
        }

        // 현재 스테이지만 켜기
        CurrentStage.stageRoot.SetActive(true);

        currentPoint = 0;

        needPoint = CurrentStage.pointItemsParent.GetComponentsInChildren<Item>(true).Length;

        CurrentStage.goalPoint.SetActive(false);

        respawnManager.SetRespawnPoint(CurrentStage.startPoint);
        uiManager.UpdateStage(currentStageIndex+1, stages.Length);
        uiManager.UpdatePoint(currentPoint,needPoint);
    }
    public void AddPoint()
    {
        currentPoint++;

        uiManager.UpdatePoint(currentPoint,needPoint);

        if (currentPoint >= needPoint)
        {
            CurrentStage.goalPoint.SetActive(true);
        }
    }

    public void NextStage()
    {
        

        currentStageIndex++;

        if (currentStageIndex >= stages.Length)
        {
            Debug.Log("게임 클리어!");
            return;
        }

        StartStage();
    }
}