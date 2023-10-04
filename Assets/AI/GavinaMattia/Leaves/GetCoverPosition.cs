using DBGA.AI.Gavina;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCoverPosition : Node
{
	private List<Vector3> covers;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out CoverSensor coverSensor))
			return Outcome.FAIL;

		covers = coverSensor.FindCoverPositions(agent.transform.position);

		if (covers.Count == 0)
			return Outcome.FAIL;

		blackboard.SetBlackboardValue("closestCover", GetClosestCover(covers, agent));
		return Outcome.SUCCESS;

	}

	private Vector3 GetClosestCover(List<Vector3> coversInRange, GameObject agent)
	{
		int closestCoverPosition = 0;
		int i = 0;
		float distanceFromItem = Vector3.Distance(coversInRange[i], agent.transform.position);

		for (i = 1; i < coversInRange.Count; i++)
		{
			if (Vector3.Distance(coversInRange[i], agent.transform.position) < distanceFromItem)
			{
				distanceFromItem = Vector3.Distance(coversInRange[i], agent.transform.position);
				closestCoverPosition = i;
			}
		}

		return coversInRange[closestCoverPosition];
	}
}
