using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;
using DBGA.AI.Common;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class BaseShootToTargetLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetAtLeastOneTarget(out GameObject target))
                return Outcome.FAIL;


            if (!agent.TryGetComponent<IInventory>(out var inventory))
                return Outcome.FAIL;

            var weapon = inventory.GetActiveWeapon();
            if (weapon == null)
                return Outcome.FAIL;

            if ((weapon as WeaponBase).GetCurrentAmmo() <= 0)
                return Outcome.FAIL;

            agent.transform.LookAt(target.transform);
            weapon.Shoot();

            return Outcome.SUCCESS;
        }

    }
}