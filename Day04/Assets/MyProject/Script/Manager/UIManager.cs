using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text stageText;
    [SerializeField] private TMP_Text pointText;

    public void UpdateStage(int currentStage, int totalStage)
    {
        stageText.text = $"Stage {currentStage} / {totalStage}";
    }

    public void UpdatePoint(int currentPoint, int needPoint)
    {
        pointText.text = $"Point {currentPoint} / {needPoint}";
    }
}