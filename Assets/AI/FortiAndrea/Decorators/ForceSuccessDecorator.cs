using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
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
