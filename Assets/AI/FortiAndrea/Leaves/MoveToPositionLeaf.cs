

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
namespace DBGA.AI.AI.FortiAndrea
{
	public class MoveToPositionLeaf : Leaf
	{
		[SerializeField, Min(0)]
		private float acceptanceRange;
		[SerializeField]
		private string positionBlackboardKey;
		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!blackboard.TryGetValueFromDictionary(positionBlackboardKey, out Vector3 targetPosition))
			{
				return Outcome.FAIL;
			}

			if (!agent.TryGetComponent<NavMeshAgent>(out var navMeshAgent))
			{
				Debug.Log("Missing NavMeshAgent");
				return Outcome.FAIL;
			}
			navMeshAgent.SetDestination(targetPosition);
			navMeshAgent.isStopped = false;

			//Debug.Log($"Moving to position: {targetPosition} ...");
			while (Vector3.Distance(agent.transform.position, targetPosition) > acceptanceRange)
			{
				await Task.Delay((int)(Time.fixedDeltaTime * 1000));
			}

			navMeshAgent.isStopped = true;
			return Outcome.SUCCESS;
		}
	}
}