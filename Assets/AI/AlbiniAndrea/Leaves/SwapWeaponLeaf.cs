using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeaponLeaf : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
            return AIEnums.FAIL;

        if(inventory.GetActiveWeapon() != null)
        {
            inventory.SwapWeapons();
            if (inventory.GetActiveWeapon() == null)
                inventory.SwapWeapons();
        }

        return AIEnums.FAIL;
    }
}
