using UnityEngine;

public class SlowZone : MonoBehaviour
{
    [SerializeField] private float slowSpeed = 1.5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.SetMoveSpeed(slowSpeed);
            return;
        }

        BotNavMesh bot = other.GetComponent<BotNavMesh>();
        if (bot != null)
        {
            bot.SetSpeed(slowSpeed);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerMove player = other.GetComponent<PlayerMove>();
        if (player != null)
        {
            player.ResetMoveSpeed();
            return;
        }

        BotNavMesh bot = other.GetComponent<BotNavMesh>();
        if (bot != null)
        {
            bot.ResetSpeed();
        }
    }
}