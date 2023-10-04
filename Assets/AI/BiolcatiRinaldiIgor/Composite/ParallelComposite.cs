using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class ParallelComposite : Composite
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            int failChildCounter = 0;
            foreach (var child in children)
                if (await child.Run(agent, blackboard) == Outcome.FAIL)
                    failChildCounter++;
            
            if(failChildCounter == children.Count)
                return Outcome.FAIL;
            else
                return Outcome.SUCCESS;
        }
    }
}