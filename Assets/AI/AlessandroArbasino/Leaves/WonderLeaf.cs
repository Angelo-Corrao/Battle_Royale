using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WonderLeaf : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        var wanderPosition = new Vector3(Random.Range(agent.transform.position.x - 3, agent.transform.position.x + 3), 0, Random.Range(agent.transform.position.z - 3, agent.transform.position.z + 3));

        while (await MoveAiAsync(iMover, agent, wanderPosition) != AIEnums.FAIL)
            return AIEnums.FAIL;
            //wanderPosition = new Vector3(Random.Range(agent.transform.position.x - 3, agent.transform.position.x + 3), 0, Random.Range(agent.transform.position.z - 3, agent.transform.position.z + 3));

        return AIEnums.SUCCESS;
    }
}
