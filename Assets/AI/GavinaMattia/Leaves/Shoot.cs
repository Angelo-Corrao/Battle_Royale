using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class Shoot : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if(inventory.GetActiveWeapon()==null)
			return Outcome.FAIL;

		inventory.GetActiveWeapon().Shoot();
		return Outcome.SUCCESS;

		

	}
}
