using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class GoToSafeLeaf : WanderBaseLeaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<StormSensor>(out StormSensor stormSensor))
            return AIEnums.FAIL;

        if (!agent.TryGetComponent<IMover>(out IMover iMover))
            return AIEnums.FAIL;

        var storm = stormSensor.GetStorm();
        var safePosition = new Vector3(Random.Range(storm.GetCenter().x - storm.GetRadius(), storm.GetCenter().x + storm.GetRadius()), 0, Random.Range(storm.GetCenter().z - storm.GetRadius(), storm.GetCenter().z + storm.GetRadius()));
        Debug.Log("Safe");
        return await MoveAiAsync( iMover, agent,safePosition);
    }


}
