using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.Collections;
using UnityEngine;

namespace Assets.Rpg.Game.Inventory
{
    public enum ItemType
    {
        Weapon,
        Armor,
        Potion
        
    }
    public class Item
    {
        private string Name { get; set; }
        private int Count { get; set; }

       public ItemType Type { get; set; }

        public Item(string name, int count, ItemType itemtype)
        {
            Name = name;
            Count = count;
            Type = itemtype;
        }

        public void UseTo(int count, Creature target)
        {
            if (Count <= 0)
            {
                Debug.Log($"남은 {Name} 아이템이 없습니다.");
                return;
            }

            int usableCount = Math.Min(count, Count);

            Debug.Log($"{Name} 아이템을 {usableCount}개 사용했습니다.");

            for (int i = 0; i < usableCount; i++)
            {
                UseEffect(target);
            }

            Count -= usableCount;
        }

        public void PrintInfo()
        {
            Debug.Log(GetStatusText());
        }

        public string GetStatusText()
        {
            return $"{Name} : {Count}개";
        }

        protected virtual void UseEffect(Creature target)
        {

        }


    }
}
