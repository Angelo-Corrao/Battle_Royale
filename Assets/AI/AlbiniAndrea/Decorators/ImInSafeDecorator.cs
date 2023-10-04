using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImInSafeDecorator : Decorator
{
	public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent<StormSensor>(out StormSensor stormSensor))
			return AIEnums.FAIL;
		var storm = stormSensor.GetStorm();
		if (storm == null || storm.GetRadius() <= 3)
			return AIEnums.FAIL;

		if (ImInRange(agent.transform.position, storm.GetCenter(), storm.GetRadius()))
			return await child.Run(agent, blackboard);


		return AIEnums.FAIL;
	}

	private bool ImInRange(Vector3 myPosition, Vector3 StormPosition, float stormRadious)
	{
		if ((myPosition.x > StormPosition.x + stormRadious - 1f || myPosition.x < StormPosition.x - stormRadious + 1f)
			 || (myPosition.z > StormPosition.z + stormRadious - 1f || myPosition.z < StormPosition.z - stormRadious + 1f))
			return true;

		return false;
	}
}
