using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class IsArmorNearAndBetterDecorator : Decorator
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensor))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;

            var nearArmors = pickableSensor.GetNearArmors();
            IArmor currentArmor = inventory.GetCurrentArmor();
            if (nearArmors.Count <= 0 ||
                (currentArmor != null &&
                    nearArmors[0].GetComponent<IArmor>().GetCurrentDurability() <= currentArmor.GetCurrentDurability()))
                return false;

            blackboard.SetValueToDictionary<GameObject>(BlackboardKey.NEAR_ARMOR, nearArmors[0]);
            return await child.Run(agent, blackboard);
        }
    }
}
