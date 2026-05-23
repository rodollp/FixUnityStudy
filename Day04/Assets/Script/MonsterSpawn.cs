using Assets.Script;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
public class MonsterSpawn : MonoBehaviour
{
    [SerializeField] List<Monster> monsters;

    public List<Monster> Monsters => monsters;

    void Spawn(Monster monster)
    {
        
    }

}
