using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class GetCoverPositionLeaf : Leaf
    {
        [SerializeField]
        private string positionBlackboardKey;

        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary(targetBlackboardKey, out GameObject target))
            {
                return Outcome.FAIL;
            }

            if (!agent.TryGetComponent<CoverSensor>(out var coverSensor))
            {
                return Outcome.FAIL;
            }

            var covers = coverSensor.FindCoverPositions(target.transform.position);
            if (covers.Count <= 0)
            {
                return Outcome.FAIL;
            }

            blackboard.SetValueToDictionary(positionBlackboardKey, covers[0]);
            return Outcome.SUCCESS;
        }
    }
}