using DBGA.AI.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class IsOutAmmoDecorator : Decorator
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<WeaponBase>(out var weapon))
            {
                return Outcome.FAIL;
            }

            return await child.Run(agent, blackboard);
        }
    }
}
