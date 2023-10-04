using DBGA.AI.Common;
using DBGA.AI.Gavina;
using DBGA.AI.Pickable;
using DBGA.AI.Movement;
using UnityEngine;

public class PickArmor : Node
{
	private GameObject closestPickable;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		closestPickable = (GameObject)blackboard.GetBlackboardValue("closestPickableArmor");

		if (!agent.TryGetComponent(out IInventory inventory))
			return Outcome.FAIL;

		if (closestPickable == null)
			return Outcome.FAIL;

		if (!closestPickable.TryGetComponent(out ArmorPicker armorPicker))
			return Outcome.FAIL;

		if(!agent.TryGetComponent(out PlayerMovement mover))
			return Outcome.FAIL;

		Vector3 direction = (new Vector3(closestPickable.transform.position.x,1, closestPickable.transform.position.z) - agent.transform.position).normalized;
		mover.MoveToward(new Vector2(direction.x, direction.z));
		mover.SetDirection(new Vector2(direction.x, direction.z));
		if (Vector3.Distance(closestPickable.transform.position, agent.transform.position) > 0.5f)
			return Outcome.RUNNING;


		armorPicker.Interact(agent);
		return Outcome.SUCCESS;
	}
}
