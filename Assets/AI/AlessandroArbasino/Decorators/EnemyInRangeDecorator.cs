using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyInRangeDecorator : Decorator
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<EyesSensor>(out EyesSensor eyes))
            return AIEnums.FAIL;

        var enemies = eyes.GetEnemiesTargets();

        if (enemies.ToList().Count <= 0)
            return AIEnums.FAIL;

        return await child.Run(agent, blackboard);
    }
}
