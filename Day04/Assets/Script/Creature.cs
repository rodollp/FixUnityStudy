using UnityEngine;


public class Creature : MonoBehaviour
{
    [Header("기본 스탯")]
    [SerializeField] private string _Name;
    [SerializeField] private int _Hp;
    [SerializeField] private int _MaxHp;
    [SerializeField] private int _Atk;

    public string Name
    {
        get { return _Name; }
    }

    public int Hp
    {
        get { return _Hp; }
        set
        {
            // HP를 0 ~ MaxHp 사이로 제한
            _Hp = Mathf.Clamp(value, 0, MaxHp);
        }
    }

    public int MaxHp
    {
        get { return _MaxHp; }
        set
        {
            // MaxHp는 최소 1 이상
            _MaxHp = Mathf.Max(1, value);

            // 현재 HP도 MaxHp 범위 안으로 보정
            _Hp = Mathf.Clamp(_Hp, 0, _MaxHp);
        }
    }

    public int Atk
    {
        get { return _Atk; }
        set
        {
            // 공격력은 음수가 될 수 없음
            _Atk = Mathf.Max(0, value);
        }
    }

    public bool IsDead
    {
        get => Hp <= 0;
    }

    public virtual void Attack(Creature target)
    {
        target.TakeDamage(Atk);

        Debug.Log($"{Name}이(가) {target.Name}을(를) 공격!");
    }

    public virtual void TakeDamage(int damage)
    {
        Hp -= damage;

        Debug.Log($"{Name}이(가) {damage}의 피해를 입었습니다! 현재 체력 : {Hp}");

        if (Hp <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        Hp = 0;
    }
}