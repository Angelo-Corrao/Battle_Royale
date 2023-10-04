using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwapWeapons : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		inventory.SwapWeapons();
		return Outcome.SUCCESS;
	}
}
