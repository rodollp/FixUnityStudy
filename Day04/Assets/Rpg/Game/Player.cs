using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Rpg.Game
{
    public class Player : Creature
    {
        [SerializeField] private int playerHp;
        [SerializeField] private int playerAtk;
        [SerializeField] private string playerName;


        private void Awake()
        {
            Hp = playerHp;
            Atk = playerAtk;
            name = playerName;
        }
        


        protected override void Die()
        {
            Debug.Log($"{name}이(가) 게임 오버되었습니다.");
        }

    }
}
