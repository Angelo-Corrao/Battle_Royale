using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class AimAndShootLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard
                .TryGetValueFromDictionary<Vector3>(BlackboardKey.ENEMY_PREDICT_POSITION, out Vector3 enemyPosition))
                return false;
            if (!agent.TryGetComponent<IMover>(out IMover mover))
                return false;
            if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
                return false;

            // Aim
            Vector3 aiToEnemyDirection = (enemyPosition - agent.transform.position).normalized;
            mover.SetDirection(new Vector2(aiToEnemyDirection.x, aiToEnemyDirection.z).normalized);

            // Shoot
            inventory.GetActiveWeapon()?.Shoot();

            return true;
        }
    }
}
