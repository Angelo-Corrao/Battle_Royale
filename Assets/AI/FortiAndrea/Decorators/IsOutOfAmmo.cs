using DBGA.AI.Common;
using DBGA.AI.Sensors;
using DBGA.AI.Weapon;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	[DisallowMultipleComponent]
	public class IsOutOfAmmo : Decorator
	{
		public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<IInventory>(out var inventory))
			{
				return Outcome.FAIL;
			}

			IWeapon weapon = inventory.GetActiveWeapon();
			if (weapon == null)
				return Outcome.FAIL;
			if (weapon.IsOutOfAmmo())
				return await child.Run(agent, blackboard);
			return Outcome.FAIL;
		}
	}
}
