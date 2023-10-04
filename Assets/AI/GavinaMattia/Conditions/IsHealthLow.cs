using DBGA.AI.Gavina;
using DBGA.AI.Health;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsHealthLow : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Health health))
			return Outcome.FAIL;

		if(health.GetCurrentHealth() > health.GetMaxHealth()*0.2f)
			return Outcome.FAIL;

		return Outcome.SUCCESS;
	}
}
