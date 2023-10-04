using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitForFireRate : Node
{
	private float timer = 0;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		timer += Time.deltaTime;
		if (timer >= inventory.GetActiveWeapon().GetFireRate()) 
		{
			timer = 0;
			return Outcome.SUCCESS;
		}

		return Outcome.FAIL;
	}
}
