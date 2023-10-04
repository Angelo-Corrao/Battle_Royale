using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class WonderLeaf : WanderBaseLeaf
{
	private Vector3 nextPos;
	public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent<IMover>(out IMover iMover))
			return AIEnums.FAIL;
		if(!agent.TryGetComponent<StormSensor>(out StormSensor storm))
			return AIEnums.FAIL;
		storm = agent.GetComponent<StormSensor>();
		var wanderPosition = Vector3.zero;

		if (storm.GetStorm()!=null && storm.GetStorm().GetRadius() > 3)
		{
			nextPos = new Vector3(Random.Range(agent.transform.position.x - 3f, agent.transform.position.x + 3f), 0, Random.Range(agent.transform.position.z - 3f, agent.transform.position.z + 3f));

			wanderPosition = (nextPos - storm.GetStorm().GetCenter()).normalized * (storm.GetStorm().GetRadius()-1f);
		}
		else
			wanderPosition = new Vector3(Random.Range(agent.transform.position.x - 3f, agent.transform.position.x + 3f), 0, Random.Range(agent.transform.position.z - 3f, agent.transform.position.z + 3f));

		return await MoveAiAsync(iMover, agent, wanderPosition);
	}
}
