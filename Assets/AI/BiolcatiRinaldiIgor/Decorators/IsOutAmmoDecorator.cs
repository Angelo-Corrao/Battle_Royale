using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class IsOutAmmoDecorator : Decorator
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<WeaponBase>(out var weapon))
                return Outcome.FAIL;
            

            //if (!weapon.IsOutOfAmmo())
            //{
            //    return Outcome.FAIL;
            //}

            return await child.Run(agent, blackboard);
        }
    }
}