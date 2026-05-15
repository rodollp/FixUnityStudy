using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

namespace Assets.Rpg.Game
{
    public class Player : Creature
    {
        [SerializeField] private int playerHp;
        [SerializeField] private int playerAtk;
        [SerializeField] private string playerName;
        [SerializeField] private int playerShield;

        public int Shield { get; private set; }

        private void Awake()
        {
            Hp = playerHp;
            Atk = playerAtk;
            name = playerName;
            Shield = playerShield;
        }

        public override void TakeDamage(int damage)
        {
            int oldDamage = damage;
            if(oldDamage > Shield)
            {
                damage -= Shield;
                Shield = 0;
                base.TakeDamage(damage);
            }
            else
            {
                Shield -= damage;
                
            }
            Debug.Log($"{name}이(가) 피해를 {oldDamage} 만큼 입습니다. 현재 HP: {Hp}, 현재 방어막: {Shield}");
            if (Hp <= 0)
            {
                Die();
            }



        }

        

        protected override void Die()
        {
            Hp = 0;
            Debug.Log($"{name}이(가) 게임 오버되었습니다.");
        }

    }
}
