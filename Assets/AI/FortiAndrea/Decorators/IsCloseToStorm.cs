using DBGA.AI.Sensors;
using DBGA.AI.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	[DisallowMultipleComponent]
	public class IsCloseToStorm : Decorator
	{
		[SerializeField] private float MaxDistanceFromStormBeforeStartMove = 5f;
		[SerializeField] private string PositionToRunFromStormBlackboardKey;
		[SerializeField] private float MoveMagnitude = 5f;

		public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<StormSensor>(out var stormSensor))
			{
				Debug.Log("missing StormSensor");
				return Outcome.FAIL;
			}
			Vector3 stormCenter = stormSensor.GetStorm().GetCenter();
			float radius = stormSensor.GetStorm().GetRadius();
			float distance = Vector3.Distance(agent.transform.position, stormCenter);
			//Debug.Log($"|IsCloseToStorm| stormCenter: {stormCenter}, radius: {radius}, distance: {distance} >? {radius - MaxDistanceFromStormBeforeStartMove}");
			if (radius - MaxDistanceFromStormBeforeStartMove > 10 && distance >= radius - MaxDistanceFromStormBeforeStartMove)
			{
				Vector3 destination = transform.position + (stormCenter - transform.position).normalized * MoveMagnitude;
				//Debug.Log($"New Destination to escape storm: {destination}");
				if (!blackboard.ContainsKey(PositionToRunFromStormBlackboardKey))
					blackboard.Add(PositionToRunFromStormBlackboardKey, destination);
				else
					blackboard[PositionToRunFromStormBlackboardKey] = destination;
				return await child.Run(agent, blackboard);
			}

			return Outcome.FAIL;
		}
	}
}
