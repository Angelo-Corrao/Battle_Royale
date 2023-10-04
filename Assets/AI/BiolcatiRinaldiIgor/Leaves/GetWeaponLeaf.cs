using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;
using DBGA.AI.Pickable;
using DBGA.AI.Common;
using DBGA.AI.Weapon;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class GetWeaponLeaf : Leaf
    {
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out var pickSensor))
                return Outcome.FAIL;

            if(!agent.TryGetComponent<IInventory>(out var inventory))
                return Outcome.FAIL;
            
            var weapons = pickSensor.GetNearWeapons();
            if (weapons.Count == 0)
                return Outcome.FAIL;

            foreach (var weapon in weapons)
                weapon.GetComponent<WeaponPicker>().Interact(agent);
            
            return Outcome.SUCCESS;
        }
    }
}