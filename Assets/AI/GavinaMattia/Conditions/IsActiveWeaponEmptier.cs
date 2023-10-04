using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsActiveWeaponEmptier : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if (inventory.GetActiveWeapon() == null)
			return Outcome.FAIL;

		if (inventory.GetBackupWeapon() == null & inventory.GetActiveWeapon().GetCurrentAmmo() < inventory.GetActiveWeapon().GetMaxAmmo()) 
			return Outcome.SUCCESS;

		if (inventory.GetBackupWeapon() != null && inventory.GetActiveWeapon().GetCurrentAmmo() <= inventory.GetBackupWeapon().GetCurrentAmmo())
			return Outcome.SUCCESS;

		return Outcome.FAIL;
	}
}
