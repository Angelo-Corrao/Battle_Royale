using DBGA.AI.Gavina;
using DBGA.AI.Weapon;
using UnityEngine;

public class IsAmmo : Decorator
{
	private GameObject closestObject;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		closestObject = (GameObject)blackboard.GetBlackboardValue("closestPickableAmmo");

		if (closestObject == null)
			return Outcome.FAIL;

		if (!closestObject.TryGetComponent(out Ammo ammo))
			return Outcome.FAIL;

		return child.Run(agent, blackboard);
	}
}
