using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class SelectorComposite : Composite
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            foreach (var child in children)
            {
                if (await child.Run(agent, blackboard) == Outcome.SUCCESS)
                {
                    return Outcome.SUCCESS;
                }
            }

            return Outcome.FAIL;
        }
    }
}