using DBGA.AI.Gavina;
using DBGA.AI.Weapon;
using UnityEngine;

public class IsWeapon : Decorator
{
	private GameObject closestObject;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		closestObject = (GameObject)blackboard.GetBlackboardValue("closestPickableWeapon");

		if (closestObject == null)
			return Outcome.FAIL;

		if (!closestObject.TryGetComponent(out WeaponBase weapon))
			return Outcome.FAIL;

		return child.Run(agent, blackboard);
	}
}

