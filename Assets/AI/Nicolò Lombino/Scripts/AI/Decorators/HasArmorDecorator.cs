using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Common;

namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class HasArmorDecorator : Decorator
    {
        public override async Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<IInventory>(out var inventory))
            {
                return Outcome.FAIL;
            }

            if (inventory.GetCurrentArmor() != null)
            {
                return Outcome.SUCCESS;
            }

            return await child.Run(agent, blackboard);
        }
    }
}
