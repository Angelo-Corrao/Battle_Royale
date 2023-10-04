using DBGA.AI.Common;
using DBGA.AI.Weapon;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using S = System;
namespace DBGA.AI.AI.FortiAndrea
{
	[DisallowMultipleComponent]
	public class AimAndShootLeaf : Leaf
	{
		[SerializeField]
		private string targetBlackboardKey;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			IWeapon weapon;
			if (!blackboard.TryGetValueFromDictionary(targetBlackboardKey, out GameObject target))
			{
				Debug.Log("No Target, can't shoot");
				return Outcome.FAIL;
			}

			if (!agent.TryGetComponent<IInventory>(out var inventory))
			{
				Debug.Log("No inventory, can't shoot");
				return Outcome.FAIL;
			}
			weapon = inventory.GetActiveWeapon();
			if (weapon == null)
			{
				Debug.Log("No weapon, can't shoot");
				return Outcome.FAIL;
			}
			//weapon.Aim((target.transform.position - agent.transform.position).normalized);
			Vector3 direction = (target.transform.position - agent.transform.position).normalized;
			agent.GetComponent<IMover>().SetDirection(new Vector2(direction.x, direction.z));
			weapon.Shoot();
			//Debug.Log("PEW PEW");

			return Outcome.SUCCESS;
		}

	}
}
