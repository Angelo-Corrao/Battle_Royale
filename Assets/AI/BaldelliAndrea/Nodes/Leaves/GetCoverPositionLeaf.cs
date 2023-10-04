using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class GetCoverPositionLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<CoverSensor>(out CoverSensor coverSensor))
                return false;
            if (!blackboard.TryGetValueFromDictionary<Vector3>(BlackboardKey.ENEMY_PREDICT_POSITION, out Vector3 target))
                return false;

            var coverPositions = coverSensor.FindCoverPositions(target);
            if (coverPositions.Count <= 0)
                return false;

            blackboard.SetValueToDictionary<Vector3>(BlackboardKey.COVER_POSITION, coverPositions[0]);
            return true;
        }
    }
}
