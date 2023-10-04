using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Pickable;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class PickWeaponLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.NEAR_WEAPON, out GameObject weaponObject))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;
            if (!weaponObject.TryGetComponent<WeaponPicker>(out WeaponPicker weaponPicker))
                return false;

            weaponPicker.Interact(agent);
            return true;
        }
    }
}
