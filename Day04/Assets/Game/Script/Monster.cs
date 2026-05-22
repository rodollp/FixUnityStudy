using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Game.Script
{
    public class Monster : Creature
    {
        [SerializeField] private Reward Reward;
        private event Action OnDeadHendle;

        public Reward reward => Reward;

        protected override void Die()
        {
            base.Die();
            OnDeadHendle?.Invoke();
        }


    }
}
