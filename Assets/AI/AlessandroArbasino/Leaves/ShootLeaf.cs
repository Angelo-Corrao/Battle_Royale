using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootLeaf : Leaf
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!blackboard
            .TryGetValueFromDictionary<GameObject>(BlackboardKey.ENEMY_POSITION, out GameObject enemyPosition))
            return AIEnums.FAIL;

        if (!blackboard
            .TryGetValueFromDictionary<Vector3>(BlackboardKey.ENEMY_PREDICT_POSITION, out Vector3 enemyDirection))
            return AIEnums.FAIL;
        if (!agent.TryGetComponent<IMover>(out IMover mover))
            return AIEnums.FAIL;
        if (!agent.TryGetComponent<IInventory>(out IInventory inventory))
            return AIEnums.FAIL;

        // Aim
        Vector3 aiToEnemyDirection = enemyDirection.normalized;
       // mover.SetDirection(new Vector2(aiToEnemyDirection.x, aiToEnemyDirection.z));
        mover.SetDirection(new Vector2(aiToEnemyDirection.x+agent.transform.rotation.x, aiToEnemyDirection.z + agent.transform.rotation.z).normalized);

        // Shoot
        if (inventory.GetActiveWeapon()==null && !inventory.GetActiveWeapon().IsOutOfAmmo())
            return AIEnums.FAIL;
        inventory.GetActiveWeapon()?.Shoot();

        return AIEnums.SUCCESS;
    }
}
