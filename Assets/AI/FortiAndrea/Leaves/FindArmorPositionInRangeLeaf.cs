using DBGA.AI.Pickable;
using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	public class FindArmorPositionInRangeLeaf : Leaf
	{
		[SerializeField]
		private string positionArmorKey;
		[SerializeField]
		private string armorToInteractkey;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<PickableSensor>(out var pickableSensor))
			{
				Debug.Log("PickableSensor missing");
				return Outcome.FAIL;
			}
			List<GameObject> weapons = pickableSensor.GetNearArmors();
			if (weapons.Count == 0)
				return Outcome.FAIL;
			if (!weapons[0].TryGetComponent<ArmorPicker>(out ArmorPicker armorPicker))
			{
				Debug.Log("object is not WeaponPicker");
				return Outcome.FAIL;
			}

			blackboard.SetValueToDictionary(positionArmorKey, armorPicker.transform.position);
			blackboard.SetValueToDictionary(armorToInteractkey, armorPicker);

			return Outcome.SUCCESS;
		}
	}
}