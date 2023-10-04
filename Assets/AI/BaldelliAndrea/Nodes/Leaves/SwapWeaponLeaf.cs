using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class SwapWeaponLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;

            inventory.SwapWeapons();
            return true;
        }
    }
}
