using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class IsSecondaryWeaponEmptier : Decorator
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory invetory))
			return Outcome.FAIL;

		if (invetory.GetBackupWeapon() == null)
			return Outcome.FAIL;

		if (invetory.GetBackupWeapon().GetCurrentAmmo() < invetory.GetActiveWeapon().GetCurrentAmmo())
			return child.Run(agent, blackboard);

		return Outcome.FAIL;
	}
}
