using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Assets.Rpg.Game.Interface;

namespace Assets.Rpg.Game.Combat
{
    internal class Test : MonoBehaviour
    {
        [SerializeField] private Transform targetParent;

        private void Start()
        {
            foreach (Transform child in targetParent)
            {
                IDamageable target = child.GetComponent<IDamageable>();

                if (target != null)
                {
                    target.TakeDamage(100);
                }
            }
           


        }

    }
}