using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class GetTargetLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<EyesSensor>(out var eyes))
                return Outcome.FAIL;


            var targets = eyes.GetEnemiesTargets();
            if (targets.Count <= 0)
                return Outcome.FAIL;

            foreach (var target in targets)
                blackboard.SetValueToDictionary("Agent: " + target.name, target);
            return Outcome.SUCCESS;
        }
    }
}