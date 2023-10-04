using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;
using DBGA.AI.Common;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class GetStormLeaf : Leaf
    {
        [SerializeField]
        private string stormKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<StormSensor>(out var stormSensor))
                return Outcome.FAIL;

            blackboard.SetValueToDictionary<IStorm>(stormKey, stormSensor.GetStorm());
            
            return Outcome.SUCCESS;
        }
    }
}