using UnityEngine;
using Unity.Cinemachine;

public class CameraValue: MonoBehaviour
{
    [SerializeField] private CinemachineCamera playerCamera;
    [SerializeField] private CinemachineCamera botCamera;

    public void ShowBotCamera()
    {
        playerCamera.Priority = 10;
        botCamera.Priority = 20;
    }

    public void ShowPlayerCamera()
    {
        playerCamera.Priority = 20;
        botCamera.Priority = 10;
    }
}