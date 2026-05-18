using UnityEngine;
using Assets.Rpg;
using Assets.Rpg.Game.Interface;

public class Barricade : MonoBehaviour,IDamageable
{
    [SerializeField] int boxHp;
    
    public  void TakeDamage(int damage)
    {
        boxHp -= damage;
        if (IsDead)
        {
            Debug.Log("장애물이 파손되었습니다");
        }
        else
        {
            Debug.Log($"{damage}만큼 피해를 입습니다. 장애물 Hp :{boxHp}");
        }

    }

   public bool IsDead {  get { return boxHp <= 0; } }
  
}
