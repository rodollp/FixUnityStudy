using Assets.Game.Script;
using UnityEngine;

public class Creature : MonoBehaviour,IDamageable
{
    [SerializeField] private string _Name;
    [SerializeField] private int _Hp;
    [SerializeField] private int _MaxHp;
    [SerializeField] private int _Atk;

    public string Name { get { return _Name; } }
    public int Hp
    {
        get { return _Hp; }
        set
        {
            _Hp = Mathf.Clamp(value, 0, MaxHp);
        }
    }

    public int MaxHp
    {
        get { return _MaxHp; }
        set
        {
            _MaxHp = Mathf.Max(1, value);
            _Hp = Mathf.Clamp(_Hp, 0, MaxHp);

        }
    }

    public int Atk
    {
        get { return _Atk; }
        set 
        { 
            _Atk = Mathf.Max(0, value);
        }

    }

    public virtual void TakeDamage(int  damage)
    {
        Hp -= damage;
        Debug.Log($"{Name}이(가) {damage}의 피해를 입었습니다! 현재 체력 : {Hp}");
        if (Hp < 0)
        {
            Die();
        }
        

    }

    protected virtual void Die()
    {
        Hp = 0;
    }

    public bool IsDead
    {
        get=> Hp <= 0;
    }

}
