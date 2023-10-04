using DBGA.AI.Common;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DBGA.AI.DamageWrapper
{
    public class DamageWrapper : MonoBehaviour
    {
        private List<IDamageable> damageables = new List<IDamageable>();

        public void AddDamagable(IDamageable toAdd)
        {
            damageables.Add(toAdd);
            damageables = damageables.OrderByDescending(x => x.GetPriority()).ToList();
        }

        public void ApplyDamage(int damage)
        {
            for (int i = 0; i < damageables.Count; i++)
            {
                damage = damageables[i].TakeDamage(damage);
                if (damage == 0)
                    break;
            }
        }
    }
}
