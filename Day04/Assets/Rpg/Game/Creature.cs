using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Rpg.Game.Interface;

namespace Assets.Rpg.Game
{
    public class Creature : MonoBehaviour,IDamageable
    {
        
        private int _Hp;
        protected int Atk { get; set; }

        public int Hp
        {
            get { return _Hp; }
            set
            {

                _Hp = Mathf.Max(0, value);

            }
        }

        public virtual void GetStatusText()
        {
            Debug.Log($"이름: {name}, HP: {Hp}, 공격력: {Atk}");
        }
        public virtual void TakeDamage(int damage)
        {
            Hp -= damage;
            Debug.Log($"{name}이(가) 피해를 {damage} 만큼 입습니다. 현재 HP: {Hp}");
            if (Hp <= 0)
            {
                Die();
            }
        }

        public virtual void Attack(IDamageable target)
        {
            Debug.Log($"{name}이(가) {target}을 공격합니다. 공격력: {Atk}");
            target.TakeDamage(Atk);
        }


        public bool IsDead
        {
            get { return Hp <= 0; }
        }
        protected virtual void Die()
        {
            Hp = 0;
            Debug.Log($"{name}이 사망했습니다.");
        }

    }
}
