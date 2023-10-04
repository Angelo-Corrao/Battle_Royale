using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class IsWeaponNearAndBetterDecorator : Decorator
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensor))
                return false;

            var nearWeapons = pickableSensor.GetNearWeapons();

            if (nearWeapons.Count <= 0)
                return false;
            if (!nearWeapons[0].TryGetComponent<IWeapon>(out IWeapon nearWeapon))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;

            IWeapon activeWeapon = inventory.GetActiveWeapon();

            if (activeWeapon == null ||
                activeWeapon.GetFireRate() < nearWeapon.GetFireRate() ||
                activeWeapon.GetDamage() < nearWeapon.GetDamage())
            {
                blackboard.SetValueToDictionary<GameObject>(BlackboardKey.NEAR_WEAPON, nearWeapons[0]);
                return await child.Run(agent, blackboard);
            }

            return false;
        }
    }
}
