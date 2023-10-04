using DBGA.AI.Common;
using DBGA.AI.Sensors;
using DBGA.AI.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	[DisallowMultipleComponent]
	public class IsMissingArmor : Decorator
	{
		public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<IInventory>(out var inventory))
			{
				return Outcome.FAIL;
			}

			IArmor armor = inventory.GetCurrentArmor();
			if (armor == null || armor.GetCurrentDurability() == 0)
				return await child.Run(agent, blackboard);
			return Outcome.FAIL;
		}
	}
}
