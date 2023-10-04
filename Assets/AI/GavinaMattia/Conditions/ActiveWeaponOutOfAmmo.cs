using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class ActiveWeaponOutOfAmmo : Decorator
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if(inventory.GetActiveWeapon() == null)
			return Outcome.FAIL;

		if(inventory.GetActiveWeapon().GetCurrentAmmo() != 0)
			return Outcome.FAIL;

		return child.Run(agent, blackboard);
	}
}
