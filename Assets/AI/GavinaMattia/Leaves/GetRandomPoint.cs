using DBGA.AI.Gavina;
using DBGA.AI.Health;
using UnityEngine;

public class GetRandomPoint : Node
{
	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		if (!agent.TryGetComponent(out Health health))
			return Outcome.FAIL;

		if(health.GetCurrentHealth() < health.GetMaxHealth()*0.5f)
			return Outcome.FAIL;

		if (blackboard.GetBlackboardValue("destination") == null)
			blackboard.SetBlackboardValue("destination", new Vector3(Random.Range(-48, 48), 1, Random.Range(-48, 48)));

		if (Vector3.Distance((Vector3)blackboard.GetBlackboardValue("destination"), agent.transform.position) < 0.1f)
			blackboard.SetBlackboardValue("destination", new Vector3(Random.Range(-48, 48), 1, Random.Range(-48, 48)));

		return Outcome.SUCCESS;
	}
}
