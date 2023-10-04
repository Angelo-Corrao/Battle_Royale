using DBGA.AI.Pickable;
using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
	public class FindAmmoPositionInRangeLeaf : Leaf
	{
		[SerializeField]
		private string positionAmmoKey;
		[SerializeField]
		private string ammoToInteractkey;

		public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
		{
			if (!agent.TryGetComponent<PickableSensor>(out var pickableSensor))
			{
				Debug.Log("PickableSensor missing");
				return Outcome.FAIL;
			}
			List<GameObject> ammos = pickableSensor.GetNearAmmos();
			if (ammos.Count == 0)
				return Outcome.FAIL;
			if (!ammos[0].TryGetComponent<AmmoPicker>(out AmmoPicker ammoPicker))
			{
				Debug.Log("object is not WeaponPicker");
				return Outcome.FAIL;
			}

			blackboard.SetValueToDictionary(positionAmmoKey, ammoPicker.transform.position);
			blackboard.SetValueToDictionary(ammoToInteractkey, ammoPicker);

			return Outcome.SUCCESS;
		}
	}
}