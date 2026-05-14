using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Rpg.Game.Inventory
{
    public class Inventory : MonoBehaviour
    {
        Dictionary<ItemType, List<Item>> items = new Dictionary<ItemType, List<Item>>();

        private void Awake()
        {

        }



    }
}
