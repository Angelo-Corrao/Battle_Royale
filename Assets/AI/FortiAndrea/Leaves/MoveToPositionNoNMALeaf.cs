

using DBGA.AI.Common;
using GluonGui.Dialog;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
namespace DBGA.AI.AI.FortiAndrea
{
	public class MoveToPositionNoNMALeaf : Leaf
	{
		[SerializeField, Min(0)]
		private float acceptanceRange;
		[SerializeField]
		private string targetBlackboardKey;

		NavMeshPath path;
		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!blackboard.TryGetValueFromDictionary(targetBlackboardKey, out Vector3 targetPosition))
			{
				return Outcome.FAIL;
			}
			if (!agent.TryGetComponent<IMover>(out IMover mover))
			{
				return Outcome.FAIL;
			}
			bool pathFound;
			path = new NavMeshPath();
			//path.ClearCorners();
			Vector3 from = agent.transform.position;
			Vector3 to = targetPosition;

			NavMeshHit hit;

			if (NavMesh.SamplePosition(from, out hit, 10f, NavMesh.AllAreas))
				from = hit.position;
			else
			{
				//Debug.Log($"from position is out of navmesh: {from}");
				return Outcome.FAIL;
			}

			if (NavMesh.SamplePosition(to, out hit, 10f, NavMesh.AllAreas))
				to = hit.position;
			else
			{
				//Debug.Log($"to position is out of navmesh: {to}");
				return Outcome.FAIL;
			}

			pathFound = NavMesh.CalculatePath(from, to, NavMesh.AllAreas, path);
			int cornerRef = 1;
			float approx = 0.05f;
			while (CheckDistance(agent.transform.position, to) && pathFound)
			{
				//Debug.Log($"cornerRef: {cornerRef} | {transform.position} - {path.corners[cornerRef]}");
				if (Mathf.Abs(agent.transform.position.x - path.corners[cornerRef].x) < approx && Mathf.Abs(agent.transform.position.z - path.corners[cornerRef].z) < approx)
					cornerRef++;
				var direction = new Vector3(path.corners[cornerRef].x, 0, path.corners[cornerRef].z);
				var playerPosition2D = new Vector2(agent.transform.position.x, agent.transform.position.z);
				var direction2D = new Vector2(direction.x - playerPosition2D.x, direction.z - playerPosition2D.y);

				mover.MoveToward(direction2D.normalized);
				mover.SetDirection(direction2D.normalized);
				await Task.Delay((int)(Time.deltaTime * 1000));
			}
			return Outcome.SUCCESS;
		}

		private bool CheckDistance(Vector3 agentpos, Vector3 destination)
		{
			var playerGroundPosition = new Vector3(agentpos.x, 0, agentpos.z);
			var destinationGroundPosition = new Vector3(destination.x, 0, destination.z);
			if (Vector3.Distance(playerGroundPosition, destinationGroundPosition) > 0.1f)
				return true;

			return false;
		}
		//private void OnDrawGizmos()
		//{
		//	Gizmos.color = Color.blue;
		//	if (path != null)
		//		foreach (var item in path.corners)
		//		{
		//			Gizmos.DrawSphere(item, 0.5f);
		//		}
		//}
	}
}