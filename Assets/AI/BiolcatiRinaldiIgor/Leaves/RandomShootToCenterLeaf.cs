using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Weapon;
using DBGA.AI.Common;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    [DisallowMultipleComponent]
    public class RandomShootToCenterLeaf : Leaf
    {
        [SerializeField, Range(0,100)]
        private int percentage;
        [SerializeField]
        private string stormKey;
        [SerializeField]
        private string percentageRandomShootKey;


        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            int perc;
            if(!blackboard.TryGetValue(stormKey,out var storm))
                return Outcome.FAIL;

            if (!agent.TryGetComponent<IInventory>(out var inventory))
                return Outcome.FAIL;

            var weapon = inventory.GetActiveWeapon();
            if(weapon == null)
                return Outcome.FAIL;
            
            if((weapon as WeaponBase).GetCurrentAmmo() <= 0)
                return Outcome.FAIL;

            if (!blackboard.TryGetValue(percentageRandomShootKey, out var savePercentage))
            {
                blackboard.SetValueToDictionary(percentageRandomShootKey, percentage);
                perc = percentage;
            }
            else
                perc = (int)savePercentage;
            
            if(Random.Range(0,100) > perc)
                return Outcome.FAIL;

            Vector3 targetPos = (storm as IStorm).GetCenter();
            
            agent.transform.LookAt(targetPos);
            weapon.Shoot();

            return Outcome.SUCCESS;
        }

    }
}