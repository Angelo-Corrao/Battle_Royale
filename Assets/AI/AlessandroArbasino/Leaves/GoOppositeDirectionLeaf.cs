using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GoOppositeDirectionLeaf : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;
        if (!blackboard
                  .TryGetValueFromDictionary<Vector3>(BlackboardKey.ENEMY_PREDICT_POSITION, out Vector3 enemyDirection))
            return AIEnums.FAIL;

        if(enemyDirection.magnitude==0)
            return AIEnums.FAIL;

        var newPosition = enemyDirection.normalized * 3 + agent.transform.position;
       return await MoveAiAsync(iMover, agent, newPosition);
    }
}
