using DBGA.AI.Armor;
using DBGA.AI.Gavina;
using UnityEngine;

public class IsArmor : Decorator
{
	private GameObject closestObject;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		closestObject = (GameObject)blackboard.GetBlackboardValue("closestPickableArmor");

		if (closestObject == null)
			return Outcome.FAIL;

		if (!closestObject.TryGetComponent(out Armor armor))
			return Outcome.FAIL;

		return child.Run(agent, blackboard);
	}
}
