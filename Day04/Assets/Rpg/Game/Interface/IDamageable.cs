using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Rpg.Game.Interface
{
    public interface IDamageable
    {
        void TakeDamage(int damage);

        bool IsDead { get; }
    }
}
