using UnityEngine;
[System.Serializable]
public struct Point
{
    public int X;
    public int Y;
    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }
}
[System.Serializable]
public struct Reward
{
    public int Gold;
    public string itemName;
    public Reward(int gold, string name)
    {
        Gold = gold;
        itemName = name;
    }
}
namespace Assets.Rpg.Game
{
    
    public class Monster : Creature
    {
        [SerializeField] private int MonsterHp;
        [SerializeField] private int MonsterAtk;
        [SerializeField] private string MonsterName;
        [SerializeField] protected Reward reward;
        [SerializeField] protected Point point;

        public Reward Reward => reward;
        public Point Point => point;

        public event System.Action<Monster> OnDead;


        private void Awake()
        {
            Hp = MonsterHp;
            Atk = MonsterAtk;
            name = MonsterName;

           
        }

        protected override void Die()
        {
            
            OnDead?.Invoke(this);
            Destroy(gameObject);

        }

    }


}