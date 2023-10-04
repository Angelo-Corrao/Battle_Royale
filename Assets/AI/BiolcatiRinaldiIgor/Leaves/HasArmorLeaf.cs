using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;
using DBGA.AI.Pickable;
using DBGA.AI.Common;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class HasArmorLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if(!agent.TryGetComponent<IInventory>(out var inventory))
                return Outcome.FAIL;
            
            if(inventory.GetCurrentArmor() == null)
                return Outcome.FAIL;
            else
                return Outcome.SUCCESS;
        }
    }
}