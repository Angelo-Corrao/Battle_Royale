using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Linq;
using System.Threading;
using UnityEngine;


public class GetCoverPositionLeaf : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<CoverSensor>(out CoverSensor coverSensor))
            return AIEnums.FAIL;

        var coverPositions = coverSensor.FindCoverPositions(agent.transform.position);
        if (coverPositions.Count <= 0)
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        var coverPosition = coverPositions.FirstOrDefault();

        await MoveAiAsync( iMover, agent, coverPosition);
        return AIEnums.SUCCESS;
    }
}

