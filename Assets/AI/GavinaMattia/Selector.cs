using UnityEngine;

namespace DBGA.AI.Gavina
{
	public class Selector : Composite
	{
		public override Outcome Run(GameObject agent, Blackboard blackboard)
		{
			foreach (Node child in children) 
			{
				switch (child.Run(agent, blackboard)) 
				{
					case Outcome.SUCCESS:
						return Outcome.SUCCESS;
					case Outcome.FAIL:
						continue;
					case Outcome.RUNNING:
						return Outcome.RUNNING;
				}
			}

			return Outcome.FAIL;
		}
	}
}
