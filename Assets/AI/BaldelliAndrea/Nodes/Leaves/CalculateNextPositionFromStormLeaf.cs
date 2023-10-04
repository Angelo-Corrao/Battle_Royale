using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class CalculateNextPositionFromStormLeaf : Leaf
    {
        [SerializeField]
        private float maxNextPositionDistance = 2;

        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<Vector3>(BlackboardKey.POSITION_OUTSIDE_STORM, out Vector3 stormPosition))
                return false;

            Vector3 nextPosition = agent.transform.position +
                (stormPosition - agent.transform.position).normalized * maxNextPositionDistance;

            blackboard.SetValueToDictionary<Vector3>(BlackboardKey.NEXT_POSITION, nextPosition);
            return true;
        }
    }
}
