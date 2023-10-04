using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class RandomEvasion : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;
        
        var newPosition = new Vector3(Random.Range(agent.transform.position.x - 1.5f, agent.transform.position.x + 1.5f), 0, Random.Range(agent.transform.position.z - 1.5f, agent.transform.position.z + 1.5f));

		return await MoveAiAsync(iMover, agent, newPosition);
	}
}
