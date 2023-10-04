using DBGA.AI.Sensors;
using DBGA.AI.Gavina;
using System.Collections.Generic;
using UnityEngine;


public class IsPickableInRange : Decorator
{
	private GameObject[] closePickables = new GameObject[3];
	private List<GameObject> pickableAmmo = new List<GameObject>();
	private List<GameObject> pickableArmor = new List<GameObject>();
	private List<GameObject> pickableWeapon =new List<GameObject>();

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (agent.TryGetComponent(out PickableSensor pickableSensor)) 
		{
			pickableAmmo = pickableSensor.GetNearAmmos();
			pickableArmor = pickableSensor.GetNearArmors();
			pickableWeapon = pickableSensor.GetNearWeapons();
			
			if (pickableAmmo.Count == 0 & pickableArmor.Count == 0 & pickableWeapon.Count == 0)
				return Outcome.FAIL;

			if (pickableAmmo.Count > 0)
				closePickables[0]=(GetClosestObject(pickableAmmo, agent));
			else
				closePickables[0] = null;
			if (pickableArmor.Count > 0)
				closePickables[1] = (GetClosestObject(pickableArmor, agent));
			else
				closePickables[1] = null;
			if (pickableWeapon.Count > 0)
				closePickables[2] = (GetClosestObject(pickableWeapon, agent));
			else
				closePickables[2] = null;

			blackboard.SetBlackboardValue("closestPickableAmmo", closePickables[0]);
			blackboard.SetBlackboardValue("closestPickableArmor", closePickables[1]);
			blackboard.SetBlackboardValue("closestPickableWeapon", closePickables[2]);
			return child.Run(agent, blackboard);
			
		}
		return Outcome.FAIL;
	}

	private GameObject GetClosestObject(List<GameObject> pickableInRange,GameObject agent)
	{
		int closestPickablePosition = 0;
		int i = 0;
		float distanceFromItem = Vector3.Distance(pickableInRange[i].transform.position, agent.transform.position);

		for (i = 1; i < pickableInRange.Count; i++)
		{
			if (Vector3.Distance(pickableInRange[i].transform.position, agent.transform.position) < distanceFromItem)
			{
				distanceFromItem = Vector3.Distance(pickableInRange[i].transform.position, agent.transform.position);
				closestPickablePosition = i;
			}
		}

		return pickableInRange[closestPickablePosition];
	}
}
