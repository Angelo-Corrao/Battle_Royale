using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class BothWeponOutOfAmmo : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if (inventory.GetActiveWeapon() == null)
			return Outcome.SUCCESS;

		if (inventory.GetActiveWeapon().GetCurrentAmmo() == 0 & inventory.GetBackupWeapon() == null)
			return Outcome.SUCCESS;

		if(inventory.GetActiveWeapon().GetCurrentAmmo() > 0 || inventory.GetBackupWeapon().GetCurrentAmmo() > 0)
			return Outcome.FAIL;

		return Outcome.SUCCESS;
	}
}
