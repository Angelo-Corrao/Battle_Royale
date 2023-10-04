using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.LombinoNicolo
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

            //weapon.Reload();

            return Outcome.SUCCESS;
        }

    }
}
