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
        [SerializeField] public List<Monster> monsters;


        private List<Monster> deadBuffer = new List<Monster>();
        public void StartCombat()
        {
            while (!player.IsDead && monsters.Any(m => m!=null && !m.IsDead))
            {
                CombatRound();
                monsters.RemoveAll(m => m == null || m.IsDead);
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

        private void OnMonsterDead(Monster monster)
        {
            Debug.Log($"{monster.name}이(가) 처치되었습니다.");
            DropReward(monster.Reward ,monster.Point);
            deadBuffer.Add(monster);

        }

        private void DropReward(Reward reward, Point position)
        {
            Debug.Log($"몬스터가 {reward.Gold} 골드와 {reward.itemName} 아이템을 드롭했습니다. 위치: ({position.X}, {position.Y})");
        }

        public void CombatRound()
        {
            foreach (var monster in monsters)
            {
                if (monster != null && !monster.IsDead)
                {
                    player.Attack(monster);
                    if (monster.IsDead)
                    {
                        continue;
                    }
                    else
                    {
                        monster.Attack(player);
                        if (player.IsDead)
                        {
                            break;
                        }
                    }
                }
            }

            monsters.RemoveAll(m => deadBuffer.Contains(m));
            deadBuffer.Clear();

        }
        private void Start()
        {
            foreach (var monster in monsters)
            {
                if (monster == null) continue;
                monster.OnDead += OnMonsterDead;
            }
            StartCombat();
        }


    }
}
