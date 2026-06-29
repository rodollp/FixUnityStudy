using UnityEngine;

public class KillZone : MonoBehaviour
{
    [SerializeField] private RespawnManager respawnManager;


    private void Awake()
    {
        if (respawnManager == null)
        {
            respawnManager = FindFirstObjectByType<RespawnManager>();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!other.CompareTag("Player"))
        {
            return;
        }
        respawnManager.RespawnPlayer();
    }
}
