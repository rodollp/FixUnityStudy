using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private TMP_Text pointText;
    [SerializeField] private StageManager stageManager;
    [SerializeField] GameObject startUI;
    [SerializeField] GameObject gameUI;
    [SerializeField] GameObject clearUI;
    
    
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
        gameUI.SetActive(false);
        clearUI.SetActive(false);
    }

    public void OnClickStartGame()
    {
        SettingUI();
        stageManager.StartGame();
    }

    public void OnClickRestartGame()
    {
        SettingUI();

        stageManager.ResetGame();
    }
    void SettingUI()
    {

        startUI.SetActive(false);
        gameUI.SetActive(true);
        clearUI.SetActive(false);
    }
    public void ShowClearCanvas()
    {
        gameUI.SetActive(false);
        clearUI.SetActive(true);
    }
}