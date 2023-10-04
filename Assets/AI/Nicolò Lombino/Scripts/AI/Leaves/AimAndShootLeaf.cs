using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;

using S = System;
using DBGA.AI.Common;

namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class AimAndShootLeaf : Leaf
    {
        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<IInventory>(out var inventory))
            {
                return Outcome.FAIL;
            }

            inventory.GetActiveWeapon().Shoot();

            return Outcome.SUCCESS;
        }

    }
}
