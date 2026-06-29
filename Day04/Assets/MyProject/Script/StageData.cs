using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StageData
{
    public GameObject stageRoot;

    public Transform startPoint;

    public GameObject goalPoint;

    public Transform pointItemsParent;
    public int NeedPoint
    {
        get
        {
            return pointItemsParent.GetComponentsInChildren<Item>(true).Length;
        }
    }
}