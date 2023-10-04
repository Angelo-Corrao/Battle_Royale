using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetEnemy : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {

        if (!agent.TryGetComponent<EyesSensor>(out EyesSensor eyesSensor))
            return AIEnums.FAIL;

        var enemies = eyesSensor.GetEnemiesTargets();
        if (enemies.Count <= 0)
            return AIEnums.FAIL;

        blackboard.SetValueToDictionary<GameObject>(BlackboardKey.ENEMY_POSITION, enemies[0]);
        return AIEnums.SUCCESS;
    }
}
