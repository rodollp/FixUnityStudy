using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody playerRb;

    private Transform currentRespawnPoint;

    public void SetRespawnPoint(Transform point)
    {
        currentRespawnPoint = point;
        RespawnPlayer();
    }

    // 플레이어 위치 및 회전,속도를 초기화 시킴
    public void RespawnPlayer()
    {
        player.position = currentRespawnPoint.position;
        player.rotation = currentRespawnPoint.rotation;

        playerRb.linearVelocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }
}