using DBGA.AI.Gavina;
using UnityEngine;

public class ChildForceSuccess : Decorator
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		child.Run(agent, blackboard);
		return Outcome.SUCCESS;
	}
}
