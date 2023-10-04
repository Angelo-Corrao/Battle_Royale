using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class IsAmmoNearDecorator : Decorator
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out PickableSensor pickableSensor))
                return false;

            var nearAmmos = pickableSensor.GetNearAmmos();
            if (nearAmmos.Count <= 0)
                return false;

            blackboard.SetValueToDictionary<GameObject>(BlackboardKey.NEAR_AMMO, nearAmmos[0]);
            return await child.Run(agent, blackboard);
        }
    }
}
