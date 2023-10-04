using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class ReloadLeaf : Leaf
    {
        [SerializeField]
        private string ammoBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {

            if (!agent.TryGetComponent<WeaponBase>(out var weapon))
                return Outcome.FAIL;


            if (!blackboard.TryGetValue(ammoBlackboardKey, out var ammo))
                return Outcome.FAIL;

            weapon.Reload((int)ammo);
            return Outcome.SUCCESS;
        }

    }
}