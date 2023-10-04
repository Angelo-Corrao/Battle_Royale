using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class IsOutOfAmmoDecorator : Decorator
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;

            if (inventory.GetActiveWeapon() != null && inventory.GetActiveWeapon().IsOutOfAmmo())
                return await child.Run(agent, blackboard);

            return false;
        }
    }
}
