using System;
using Assets.MyProject.Script.Manager;
using UnityEngine;

public class GoalPoint : MonoBehaviour
{
    public event Action OnPlayerCheck;
    public event Action OnBotCheck; 
    
    private void OnTriggerEnter(Collider other)
    {
        
        BotNavMesh bot = other.GetComponentInParent<BotNavMesh>();
        if (bot != null)
        {
            OnBotCheck?.Invoke();
            return;
        }

        
        if (!other.CompareTag("Player"))
            return;

        OnPlayerCheck?.Invoke();
    }
}