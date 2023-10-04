using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class WonderToAmmoLeaf : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensors))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IInventory>(out IInventory myInventory))
            return AIEnums.FAIL;

        var pickableAmmoList = pickableSensors.GetNearAmmos();
        if (pickableAmmoList.Count <= 0)
            return AIEnums.FAIL;

        var pickableAmmo = pickableAmmoList.FirstOrDefault();

        await MoveAiAsync(iMover, agent, pickableAmmo.transform.position);

        if (pickableAmmo == null)
            return AIEnums.FAIL;

        if (!pickableAmmo.TryGetComponent<IInteractable>(out IInteractable interact))
            return AIEnums.FAIL;
        interact.Interact(agent);
        return AIEnums.SUCCESS;
    }
}
