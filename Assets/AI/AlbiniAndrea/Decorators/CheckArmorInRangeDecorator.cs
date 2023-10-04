using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CheckArmorInRangeDecorator : Decorator
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensors))
            return AIEnums.FAIL;

        var pickableArmor = pickableSensors.GetNearArmors();

        if (pickableArmor.ToList().Count <= 0)
            return AIEnums.FAIL;

         return await child.Run(pickableArmor.FirstOrDefault(), blackboard);
    }
}
