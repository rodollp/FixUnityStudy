using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Rpg.Game.Combat
{
    public class CombatSystem : MonoBehaviour
    {
        [SerializeField] public Player player;
        [SerializeField] public Monster[] monsters;


        public void StartCombat()
        {
            while (!player.IsDead && monsters.Any(m => !m.IsDead))
            {
                CombatRound();
            }

            if (player.IsDead)
            {
                Debug.Log("플레이어가 패배했습니다.");
            }
            else
            {
                Debug.Log("플레이어가 승리했습니다!");
            }

        }

        public void CombatRound()
        {
            for (int i = 0; i < monsters.Length; i++)
            {
                player.Attack(monsters[i]);
            }
            for (int i = 0; i < monsters.Length; i++)
            {
                if (!monsters[i].IsDead)
                {
                    monsters[i].Attack(player);
                }
            }
        }
        private void Start()
        {
            StartCombat();
        }


    }
}
