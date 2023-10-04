using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class GetPositionOutsideStormLeaf : Leaf
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!agent.TryGetComponent<StormSensor>(out StormSensor stormSensor))
                return false;

            IStorm storm = stormSensor.GetStorm();
            Vector3 stormCenter = storm.GetCenter();
            float stormRadius = storm.GetRadius();
            Vector3 randomDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f)).normalized;

            Vector3 positionOutsideStorm = stormCenter + randomDirection * Random.Range(0, stormRadius*3);
            blackboard.SetValueToDictionary<Vector3>(BlackboardKey.POSITION_OUTSIDE_STORM, positionOutsideStorm);
            return true;
        }
    }
}
