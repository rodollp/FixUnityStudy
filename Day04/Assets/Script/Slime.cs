using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script
{
    public class Slime : Monster
    {

        protected override void Die()
        {
            base.Die();
            Debug.Log("슬라임 사망");
        }

    }
}
