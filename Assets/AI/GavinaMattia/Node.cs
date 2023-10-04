using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.Gavina
{
	public abstract class Node : MonoBehaviour
	{
		public abstract Outcome Run(GameObject agent, Blackboard blackboard);
	}
}
