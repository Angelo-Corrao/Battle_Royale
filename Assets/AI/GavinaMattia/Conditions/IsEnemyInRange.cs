using DBGA.AI.Gavina;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsEnemyInRange : Decorator
{
	 

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out EyesSensor eyes))
			return Outcome.FAIL;

		List<GameObject> enemies = eyes.GetEnemiesTargets();

		if(enemies.Count == 0)
			return Outcome.FAIL;

		blackboard.SetBlackboardValue("closestEnemy", GetClosestEnemy(enemies, agent));
		return child.Run(agent,blackboard);

	}

	private GameObject GetClosestEnemy(List<GameObject> enemies, GameObject agent)
	{
		int closestPickablePosition = 0;
		int i = 0;
		float distanceFromItem = Vector3.Distance(enemies[i].transform.position, agent.transform.position);

		for (i = 1; i < enemies.Count; i++)
		{
			if (Vector3.Distance(enemies[i].transform.position, agent.transform.position) < distanceFromItem)
			{
				distanceFromItem = Vector3.Distance(enemies[i].transform.position, agent.transform.position);
				closestPickablePosition = i;
			}
		}

		return enemies[closestPickablePosition];
	}
}
