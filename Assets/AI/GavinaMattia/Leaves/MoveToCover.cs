using DBGA.AI.Gavina;
using DBGA.AI.Movement;
using UnityEngine;

public class MoveToCover : Node
{
	private Vector3 closestCoverPosition;
	private Vector3 direction;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out PlayerMovement mover))
			return Outcome.FAIL;

		if(blackboard.GetBlackboardValue("closestCover") == null)
			return Outcome.FAIL;

		closestCoverPosition = (Vector3)blackboard.GetBlackboardValue("closestCover");
		direction = (closestCoverPosition - agent.transform.position).normalized;

		mover.MoveToward(new Vector2(direction.x, direction.z));
		if (Vector3.Distance(agent.transform.position, closestCoverPosition) > 0.1f)
			return Outcome.RUNNING;

		return Outcome.SUCCESS;

	}
}
