

using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	public class RandomPositionInRangeLeaf : Leaf
	{
		[SerializeField]
		private string positionBlackboardKey;

		[SerializeField] private float MinRange;
		[SerializeField] private float MaxRange;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			var offset = new Vector3(Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)), 0, Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)));
			Vector3 destination = agent.transform.position + offset;

			if (!agent.TryGetComponent<StormSensor>(out var stormSensor))
			{
				return Outcome.FAIL;
			}
			int i = 0;
			for (i = 0; i < 30; i++)
			{

				if (Mathf.Abs(destination.x) > stormSensor.GetStorm().GetRadius() - stormSensor.GetStorm().GetCenter().x || Mathf.Abs(destination.z) > stormSensor.GetStorm().GetRadius() - stormSensor.GetStorm().GetCenter().z)
				{
					offset = new Vector3(Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)), 0, Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)));
					destination = agent.transform.position + offset;
				}
				else
					break;
			}

			blackboard.SetValueToDictionary(positionBlackboardKey, destination);
			//Debug.Log($"New random position: {destination} after {i} try");
			return Outcome.SUCCESS;
		}
	}
}