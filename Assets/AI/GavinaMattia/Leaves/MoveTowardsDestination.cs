using DBGA.AI.Gavina;
using DBGA.AI.Movement;
using UnityEngine;

public class MoveTowardsDestination : Node
{
	private Vector3 destination;
	private Vector3 direction;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out PlayerMovement mover))
			return Outcome.FAIL;

		destination = (Vector3)blackboard.GetBlackboardValue("destination");
		direction = (destination - agent.transform.position).normalized;

		mover.MoveToward(new Vector2(direction.x,direction.z));
		mover.SetDirection(new Vector2(direction.x, direction.z));
		if (Vector3.Distance(destination, agent.transform.position) > 0.1f)
			return Outcome.RUNNING;

		return Outcome.SUCCESS;
	}
}
