using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;

public class CheckPlayerDirLeaf : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<EyesSensor>(out EyesSensor eyesSensor))
            return AIEnums.FAIL;

        blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.ENEMY_POSITION, out var enemyPosition);
        Vector3 enemyPredictedPosition;

        if (enemyPosition != null)
            enemyPredictedPosition = await CalculatePlayerDirection(enemyPosition);
        else
            return AIEnums.FAIL;
        blackboard.SetValueToDictionary<Vector3>(BlackboardKey.ENEMY_PREDICT_POSITION, enemyPredictedPosition);
        return AIEnums.SUCCESS;
    }

    private async UniTask<Vector3> CalculatePlayerDirection(GameObject followEnemy)
    {
        var enemyPosition = followEnemy.transform.position;
        var newEnemyPosition = followEnemy.transform.position;

        return newEnemyPosition-enemyPosition;
    }
}
