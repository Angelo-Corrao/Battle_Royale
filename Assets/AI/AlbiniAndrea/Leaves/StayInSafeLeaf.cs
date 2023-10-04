using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class StayInSafeLeaf : WanderBaseLeaf
{
	public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent<StormSensor>(out StormSensor stormSensor))
			return AIEnums.FAIL;

		if (!agent.TryGetComponent<IMover>(out IMover iMover))
			return AIEnums.FAIL;

		var storm = stormSensor.GetStorm();
		var safePosition = (storm.GetCenter() - agent.transform.position).normalized + agent.transform.position;

		return await MoveAiAsync(iMover, agent, safePosition);
	}


}
