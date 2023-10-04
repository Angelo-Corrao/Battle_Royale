using DBGA.AI.Common;
using DBGA.AI.Sensors;
using DBGA.AI.Weapon;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using UnityEngine;

using S = System;
namespace DBGA.AI.AI.FortiAndrea
{
	[DisallowMultipleComponent]

	public class InteractWithObject : Leaf
	{
		[SerializeField] private string objectToInteractWithKey;
		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!blackboard.TryGetValueFromDictionary(objectToInteractWithKey, out IInteractable interactableObject))
			{
				Debug.Log("Missing object to interact with");
				return Outcome.FAIL;
			}
			if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
			{
				Debug.Log("Missing IInventory in agent");
				return Outcome.FAIL;
			}

			interactableObject.Interact(agent);
			//Debug.Log($"Interacted with object");
			return Outcome.SUCCESS;
		}
	}
}
