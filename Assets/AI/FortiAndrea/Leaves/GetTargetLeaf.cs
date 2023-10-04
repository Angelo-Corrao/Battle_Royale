

using DBGA.AI.Sensors;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
    public class GetTargetLeaf : Leaf
    {
        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<EyesSensor>(out var eyes))
            {
                return Outcome.FAIL;
            }

            var targets = eyes.GetEnemiesTargets();
            if (targets.Count <= 0)
            {
                return Outcome.FAIL;
            }

            blackboard.SetValueToDictionary(targetBlackboardKey, targets[0]);
            return Outcome.SUCCESS;
        }
    }
}