using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private StageManager stageManager;
    [SerializeField] GameObject startCanvas;
    [SerializeField] GameObject gameCanvas;
    [SerializeField] GameObject clearCanvas;

    
    public void UpdateStage(int currentStage, int totalStage)
    {
        stageText.text = $"Stage {currentStage} / {totalStage}";
    }

    public void UpdatePoint(int currentPoint, int needPoint)
    {
        pointText.text = $"Point {currentPoint} / {needPoint}";
    }

    private void Awake()
    {
        gameCanvas.SetActive(false);
        clearCanvas.SetActive(false);
    }

    public void OnClickStartGame()
    {
        SettingUI();
        stageManager.StartGame();
    }

    public void OnClickRestartGame()
    {
        SettingUI();

        stageManager.StartGame();
    }
    void SettingUI()
    {

        startCanvas.SetActive(false);
        gameCanvas.SetActive(true);
        clearCanvas.SetActive(false);
    }
    public void ShowClearCanvas()
    {
        gameCanvas.SetActive(false);
        clearCanvas.SetActive(true);
    }
}