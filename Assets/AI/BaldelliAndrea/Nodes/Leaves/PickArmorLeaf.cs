using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Pickable;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class PickArmorLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.NEAR_ARMOR, out GameObject ammoObject))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;
            if (!ammoObject.TryGetComponent<ArmorPicker>(out ArmorPicker armorPicker))
                return false;

            armorPicker.Interact(agent);
            return true;
        }
    }
}
