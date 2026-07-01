using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class StageData
{
    public GameObject stageRoot;

    public Transform startPoint;

    public GameObject goalPoint;

    public Transform pointItemsParent;
    //부모를 넣었을 때 안에있는 자식들에게서 Item클래스가 들어있는 것의 수를 나타낸다
    public int NeedPoint
    {
        get
        {
            return pointItemsParent.GetComponentsInChildren<Item>(true).Length;
        }
    }
}