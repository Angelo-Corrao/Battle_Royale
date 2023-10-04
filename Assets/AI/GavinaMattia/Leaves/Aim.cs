using DBGA.AI.Gavina;
using DBGA.AI.Movement;
using UnityEngine;

public class Aim : Node
{
	private GameObject closestEnemy;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out PlayerMovement mover))
			return Outcome.FAIL;

		closestEnemy = (GameObject)blackboard.GetBlackboardValue("closestEnemy");

		Vector3 direction = (closestEnemy.transform.position - agent.transform.position).normalized;
		mover.SetDirection(new Vector2(direction.x, direction.z));
		return Outcome.SUCCESS;

	}
}
