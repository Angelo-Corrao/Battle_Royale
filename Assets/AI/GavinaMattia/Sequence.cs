using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.Gavina
{
	public class Sequence : Composite
	{
		private bool runningChild;

		public override Outcome Run(GameObject agent, Blackboard blackboard)
		{
			runningChild = false;

			foreach (Node child in children) 
			{
				switch (child.Run(agent, blackboard)) 
				{
					case Outcome.SUCCESS:
						continue;
					case Outcome.FAIL:
						return Outcome.FAIL;
					case Outcome.RUNNING:
						runningChild = true;
						return Outcome.RUNNING;
				}
			}

			return runningChild ? Outcome.RUNNING : Outcome.SUCCESS;
		}
	}
}
