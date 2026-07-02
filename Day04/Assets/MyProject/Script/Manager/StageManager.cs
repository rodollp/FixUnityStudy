using Assets.MyProject.Script.Manager;
using UnityEngine;


public class StageManager : MonoBehaviour
{

    [Header("연결된 매니져")]
    [SerializeField] private RespawnManager respawnManager;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private BotManager botManager;
    [Header("현재 스테이지")]
    [SerializeField] private StageData[] stages;
    [Header("Player")]
    [SerializeField]private PlayerMove playerMove;


    

    //스테이지 번호
    private int currentStageIndex;
    //스테이지데이터 번호에 있는 정보를 가져온다
    StageData CurrentStage => stages[currentStageIndex];
    //클리어시 필요한 포인트 수
    private int needPoint;
    //현재 모은 포인트
    private int currentPoint;

    private GoalPoint currentGoalPoint;
    private void Awake()
    {
        
        playerMove.gameObject.SetActive(false);
        
    }
    public void StartGame()
    {
        playerMove.gameObject.SetActive(true);
        currentStageIndex = 0;
        StartStage();
        
    }
    public void ResetGame()
    {
        currentStageIndex = 0;
        StartStage();

    }
    private void StartStage()
    {
        ClearStageData();
        ActiveStage();
        ResetPointItems();
        ResetGoal();
        SetupRespawn();
        UpdateStageUI();
        SetupEvent();
        TryStartBotStage();
    }

    private void ClearStageData()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].stageRoot.SetActive(false);
        }
    }

    private void ActiveStage()
    {
        CurrentStage.stageRoot.SetActive(true);
    }

    private void ResetPointItems()
    {
        Item[] pointItems =
            CurrentStage.pointItemsParent.GetComponentsInChildren<Item>(true);

        for (int i = 0; i < pointItems.Length; i++)
        {
            pointItems[i].gameObject.SetActive(true);
        }

        currentPoint = 0;
        needPoint = pointItems.Length;
    }

    private void ResetGoal()
    {
        CurrentStage.goalPoint.SetActive(CurrentStage.goalActiveOnStart);
    }

    private void SetupRespawn()
    {
        respawnManager.SetRespawnPoint(CurrentStage.startPoint);
    }

    private void UpdateStageUI()
    {
        uiManager.UpdateStage(currentStageIndex + 1, stages.Length);
        uiManager.UpdatePoint(currentPoint, needPoint);
    }

    private void TryStartBotStage()
    {
        if (currentStageIndex != 2) return;

        botManager.StartBotStage(CurrentStage.stageRoot);

    }
    public void AddPoint()
    {
        currentPoint++;

        uiManager.UpdatePoint(currentPoint, needPoint);

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
            uiManager.ShowClearCanvas();
            
            return;
        }

        StartStage();
    }
    
    void SetupEvent()
    {
        currentGoalPoint = CurrentStage.goalPoint.GetComponent<GoalPoint>();
        currentGoalPoint.OnBotCheck -= botManager.BotArrived;
        currentGoalPoint.OnPlayerCheck -= NextStage;

        currentGoalPoint.OnBotCheck += botManager.BotArrived;
        currentGoalPoint.OnPlayerCheck += NextStage;
    }
}