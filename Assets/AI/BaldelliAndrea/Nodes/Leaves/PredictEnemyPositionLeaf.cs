using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class PredictEnemyPositionLeaf : Leaf
    {
        [SerializeField]
        private int predictionFrames = 5;

        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.ENEMY, out GameObject currentEnemy) ||
                currentEnemy == null)
                return false;

            Vector3 enemyPreviousPosition = currentEnemy.transform.position;
            await UniTask.DelayFrame(predictionFrames);

            Vector3 enemyVelocity = currentEnemy.transform.position - enemyPreviousPosition;
            blackboard.SetValueToDictionary<Vector3>(
                BlackboardKey.ENEMY_PREDICT_POSITION,
                currentEnemy.transform.position + enemyVelocity);

            return true;
        }
    }
}
