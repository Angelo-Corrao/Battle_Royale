using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class GetEnemyDecorator : Decorator
    {
        [SerializeField]
        private float maxEnemyDistance = 7;

        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (blackboard.TryGetValueFromDictionary<GameObject>(BlackboardKey.ENEMY, out GameObject currentEnemy) &&
                currentEnemy != null &&
                Vector3.Distance(currentEnemy.transform.position, agent.transform.position) <= maxEnemyDistance)
                return await child.Run(agent, blackboard);

            if (!agent.TryGetComponent<EyesSensor>(out EyesSensor eyesSensor))
                return false;

            var enemies = eyesSensor.GetEnemiesTargets();
            if (enemies.Count <= 0)
            {
                blackboard.SetValueToDictionary<GameObject>(BlackboardKey.ENEMY, null);
                return false;
            }

            blackboard.SetValueToDictionary<GameObject>(BlackboardKey.ENEMY, enemies[0]);
            return await child.Run(agent, blackboard);
        }
    }
}
