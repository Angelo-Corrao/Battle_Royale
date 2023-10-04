using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WeaponInRangeDecorator : Decorator
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensors))
            return AIEnums.FAIL;

        var pickableWeapon = pickableSensors.GetNearWeapons();

        if (pickableWeapon.ToList().Count <= 0)
            return AIEnums.FAIL;

        return await child.Run(agent, blackboard);
    }
}
