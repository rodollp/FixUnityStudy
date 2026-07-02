using System;
using Assets.MyProject.Script.Manager;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    public Action OnPlayerCheck;
    public Action OnBotCheck;
    
    private void OnTriggerEnter(Collider other)
    {
        // GuideBot µµÂø
        BotNavMesh bot = other.GetComponentInParent<BotNavMesh>();
        if (bot != null)
        {
            OnBotCheck?.Invoke();
            return;
        }

        // Player µµÂø
        if (!other.CompareTag("Player"))
            return;

        OnPlayerCheck?.Invoke();
    }
}