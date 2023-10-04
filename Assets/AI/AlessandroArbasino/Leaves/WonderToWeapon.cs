using Codice.CM.Client.Differences.Merge;
using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class WonderToWeapon : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensors))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IInventory>(out IInventory myInventory))
            return AIEnums.FAIL;

        var pickableWeaponList = pickableSensors.GetNearWeapons();
        if (pickableWeaponList.ToList().Count <= 0)
            return AIEnums.FAIL;

        var pickableWeapon = pickableWeaponList.FirstOrDefault();
        await MoveAiAsync(iMover, agent, pickableWeapon.transform.position);

        if(pickableWeapon == null)
            return AIEnums.FAIL;

        if (!pickableWeapon.TryGetComponent<IInteractable>(out IInteractable interact))
            return AIEnums.FAIL;
        interact.Interact(agent);
        return AIEnums.SUCCESS;
    }

}
