using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using UnityEngine;

public class WonderToArmor : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensors))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IInventory>(out IInventory myInventory))
            return AIEnums.FAIL;

        var pickableArmorList = pickableSensors.GetNearArmors();
        if (pickableArmorList.ToList().Count <= 0)
            return AIEnums.FAIL;

        var pickableArmor = pickableArmorList.FirstOrDefault();
        await MoveAiAsync(iMover, agent, pickableArmor.transform.position);

        if (pickableArmor == null)
            return AIEnums.FAIL;
        Debug.Log("ammo");
        if (!pickableArmor.TryGetComponent<IInteractable>(out IInteractable interact))
            return AIEnums.FAIL;

        interact.Interact(agent);
        return AIEnums.SUCCESS;
    }
}
