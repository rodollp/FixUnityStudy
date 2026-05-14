using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Day04 : MonoBehaviour
{

    public class Creature 
    {
        public string name { get; protected set; }
        private int _Hp;

        public int Hp
        {
            get { return _Hp; }
            set
            {

                _Hp = Mathf.Max(0, value);

            }
        }

        public Creature(string name, int hp)
        {
            this.name = name;
            Hp = hp;
        }
        public void TakeDamage(int damage)
        {
            Hp -= damage;
            Debug.Log($"{name}이(가) 피해를 {damage} 만큼 입습니다. 현재 HP: {Hp}");
            if (Hp <= 0)
            {
                Die();
            }
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
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Creature goblin = new Creature("Goblin", 100);
        goblin.TakeDamage(30);
        goblin.TakeDamage(80);

    }

    // Update is called once per frame

}
