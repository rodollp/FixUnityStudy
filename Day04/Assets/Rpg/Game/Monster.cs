using UnityEngine;

namespace Assets.Rpg.Game
{
    public class Monster : Creature
    {
        [SerializeField] private int MonsterHp;
        [SerializeField] private int MonsterAtk;
        [SerializeField] private string MonsterName;

        private void Awake()
        {
            Hp = MonsterHp;
            Atk = MonsterAtk;
            name = MonsterName;
        }

        protected override void Die()
        {
            Debug.Log($"{name}이(가) 쓰러졌습니다.");
        }

    }

}