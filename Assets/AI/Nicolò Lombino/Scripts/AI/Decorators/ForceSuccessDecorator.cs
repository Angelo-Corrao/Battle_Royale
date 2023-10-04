using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class ForceSuccessDecorator : Decorator
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            await child.Run(agent, blackboard);

            return Outcome.SUCCESS;
        }
    }
}
