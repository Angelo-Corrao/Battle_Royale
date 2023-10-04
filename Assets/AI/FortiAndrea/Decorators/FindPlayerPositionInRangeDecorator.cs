using DBGA.AI.Pickable;
using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	public class FindPlayerPositionInRangeDecorator : Decorator
	{
		[SerializeField]
		private string positionRunFromEnemyKey;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<EyesSensor>(out var eyeSensor))
			{
				Debug.Log("eyeSensor missing");
				return Outcome.FAIL;
			}

			List<GameObject> enemies = eyeSensor.GetEnemiesTargets();
			if (enemies.Count == 0)
				return Outcome.FAIL;

			blackboard.SetValueToDictionary(positionRunFromEnemyKey, agent.transform.position + (agent.transform.position - enemies[0].transform.position).normalized * 3);
			return await child.Run(agent, blackboard);
		}
	}
}