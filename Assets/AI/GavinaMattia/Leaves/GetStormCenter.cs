using DBGA.AI.Gavina;
using DBGA.AI.Sensors;
using UnityEngine;

public class GetStormCenter : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out StormSensor storm))
			return Outcome.FAIL;

		if (blackboard.GetBlackboardValue("destination") == null)
			blackboard.SetBlackboardValue("destination", storm.GetStorm().GetCenter());

		if (Vector3.Distance((Vector3)blackboard.GetBlackboardValue("destination"), agent.transform.position) < 0.1f)
			blackboard.SetBlackboardValue("destination", storm.GetStorm().GetCenter());

		return Outcome.SUCCESS;
	}
}
