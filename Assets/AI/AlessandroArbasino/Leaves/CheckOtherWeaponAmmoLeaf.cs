using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlasticGui.LaunchDiffParameters;

public class CheckOtherWeaponAmmoLeaf : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
            return AIEnums.FAIL;

        // TODO: Add is out of ammo
        if (inventory.GetActiveWeapon().IsOutOfAmmo())
            return AIEnums.SUCCESS;

        return AIEnums.FAIL;


    }
}
