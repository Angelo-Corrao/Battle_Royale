using DBGA.AI.Weapon;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using S = System;
namespace DBGA.AI.AI.FortiAndrea
{
    [DisallowMultipleComponent]
    public class ReloadLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {

            if (!agent.TryGetComponent<WeaponBase>(out var weapon))
            {
                return Outcome.FAIL;
            }

            //TODO IMPLEMENT RELOAD
            //weapon.Reload();

            return Outcome.SUCCESS;
        }

    }
}
