using DBGA.AI.Pickable;
using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	public class FindWeaponPositionInRangeLeaf : Leaf
	{
		[SerializeField]
		private string positionWeaponKey;
		[SerializeField]
		private string weaponToInteractkey;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<PickableSensor>(out var pickableSensor))
			{
				Debug.Log("PickableSensor missing");
				return Outcome.FAIL;
			}
			List<GameObject> weapons = pickableSensor.GetNearWeapons();
			if (weapons.Count == 0)
				return Outcome.FAIL;
			if (!weapons[0].TryGetComponent<WeaponPicker>(out WeaponPicker weaponPicker))
			{
				Debug.Log("object is not WeaponPicker");
				return Outcome.FAIL;
			}

			blackboard.SetValueToDictionary(positionWeaponKey, weaponPicker.transform.position);
			blackboard.SetValueToDictionary(weaponToInteractkey, weaponPicker);

			return Outcome.SUCCESS;
		}
	}
}