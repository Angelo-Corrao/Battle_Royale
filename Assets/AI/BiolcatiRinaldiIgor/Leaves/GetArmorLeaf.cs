using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;
using DBGA.AI.Pickable;
using DBGA.AI.Common;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class GetArmorLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out var pickSensor))
                return Outcome.FAIL;

            if(!agent.TryGetComponent<IInventory>(out var inventory))
                return Outcome.FAIL;
            
            var armors = pickSensor.GetNearArmors();
            if (armors.Count == 0)
                return Outcome.FAIL;
            else if(armors.Count > 1)
                armors[Random.Range(0,armors.Count)].GetComponent<ArmorPicker>().Interact(agent);
            else
                armors[0].GetComponent<ArmorPicker>().Interact(agent);
            
            return Outcome.SUCCESS;
        }
    }
}