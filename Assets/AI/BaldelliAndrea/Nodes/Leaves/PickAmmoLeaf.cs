using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Pickable;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class PickAmmoLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.NEAR_AMMO, out GameObject ammoObject))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;
            if (!ammoObject.TryGetComponent<AmmoPicker>(out AmmoPicker ammoPicker))
                return false;

            ammoPicker.Interact(agent);
            return true;
        }
    }
}
