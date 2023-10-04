using DBGA.AI.Armor;
using DBGA.AI.Gavina;
using DBGA.AI.Inventory;
using UnityEngine;

public class IsArmorOnTheGroundBetter : Node
{
	private Armor closestObject;

	public override Outcome Run(GameObject agent, Blackboard blackboard)
	{
		closestObject = ((GameObject)blackboard.GetBlackboardValue("closestPickableArmor")).GetComponent<Armor>();

		if (!agent.TryGetComponent(out Inventory inventory))
			return Outcome.FAIL;

		if(inventory.GetCurrentArmor() == null)
			return Outcome.SUCCESS;

		if (closestObject.GetCurrentDurability() <= agent.GetComponent<Inventory>().GetCurrentArmor().GetCurrentDurability())
			return Outcome.FAIL;

		return Outcome.SUCCESS;

	}
}
