using UnityEngine;

public class StageManager : MonoBehaviour
{

    [Header("연결된 매니져")]
    [SerializeField] private RespawnManager respawnManager;
    [SerializeField] private UIManager uiManager;
    [Header("현재 스테이지")]
    [SerializeField] private StageData[] stages;

    //스테이지 번호
    private int currentStageIndex;
    //현재 모은 포인트
    private int currentPoint;

    private BotNavMesh botNavMesh;
    private CameraValue cameraValue;
    private PlayerMove playerMove;
    [SerializeField] private GameObject player;

    //스테이지 데이터에 있는 정보를 가져온다
    StageData CurrentStage => stages[currentStageIndex];
    //클리어시 필요한 포인트 수
    private int needPoint;

    private void Awake()
    {
        cameraValue = FindFirstObjectByType<CameraValue>();
        playerMove = FindFirstObjectByType<PlayerMove>(FindObjectsInactive.Include);
        player.SetActive(false);
    }
    public void StartGame()
    {
        player.SetActive(true);
        currentStageIndex = 0;
        StartStage();
        
    }
    public void ResetGame()
    {
        currentStageIndex = 0;
        botNavMesh.ResetBot();
        StartStage();

    }
    private void StartStage()
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].stageRoot.SetActive(false);
        }

        CurrentStage.stageRoot.SetActive(true);

        // 현재 스테이지의 포인트 아이템 전부 켜기
        Item[] pointItems = CurrentStage.pointItemsParent.GetComponentsInChildren<Item>(true);

        for (int i = 0; i < pointItems.Length; i++)
        {
            pointItems[i].gameObject.SetActive(true);
        }

        currentPoint = 0;

        needPoint = pointItems.Length;

        CurrentStage.goalPoint.SetActive(CurrentStage.goalActiveOnStart);

        respawnManager.SetRespawnPoint(CurrentStage.startPoint);

        uiManager.UpdateStage(currentStageIndex + 1, stages.Length);
        uiManager.UpdatePoint(currentPoint, needPoint);

        if (currentStageIndex == 2)
        {
            botNavMesh = CurrentStage.stageRoot.GetComponentInChildren<BotNavMesh>(true);
            playerMove.enabled = false;

            cameraValue.ShowBotCamera();
            botNavMesh.StartBot();
        }
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
    public void BotArrived()
    {
        // 카메라 플레이어로 전환
        cameraValue.ShowPlayerCamera();

        // 플레이어 조작 허용
        playerMove.enabled = true;
        botNavMesh.HideBot();
    }

}