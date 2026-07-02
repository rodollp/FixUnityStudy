using UnityEngine;

public class RespawnManager : MonoBehaviour
{
    [Header("리스폰 장소를 보내기 위한 플레이어 대입")]
    [SerializeField] private Transform player;
    [SerializeField] private Rigidbody playerRb;

    private Transform currentRespawnPoint;

    //StageData에 있는 startpoint를 넣기 위해 Public 사용, stagemanager에서 연결
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