using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckEnoughtWeaponAmmoLeaf : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
            return AIEnums.FAIL;

        if(inventory.GetActiveWeapon()!=null)
            if(inventory.GetActiveWeapon().IsOutOfAmmo())
                return AIEnums.SUCCESS;

        return AIEnums.FAIL;
    }
}
