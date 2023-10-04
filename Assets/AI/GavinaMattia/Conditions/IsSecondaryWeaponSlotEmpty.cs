using DBGA.AI.Common;
using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class IsSecondaryWeaponSlotEmpty : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if (inventory.GetActiveWeapon() == null)
			return Outcome.FAIL;

		if (inventory.GetBackupWeapon() != null)
			return Outcome.FAIL;

		return Outcome.SUCCESS;

	}
}

