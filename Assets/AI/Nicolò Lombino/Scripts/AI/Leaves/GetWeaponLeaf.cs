using DBGA.AI.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using DBGA.AI.Sensors;
using DBGA.AI.Movement;
using UnityEngine.UIElements;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class GetWeaponLeaf : Leaf
    {
        [SerializeField, Min(0)]
        private float acceptanceRange;

        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<PickableSensor>(out var eyes))
            {
                return Outcome.FAIL;
            }

            List<GameObject> weapons = new List<GameObject>();
            weapons = eyes.GetNearWeapons();
            if (weapons.Count <= 0)
            {
                return Outcome.FAIL;
            }

            blackboard.SetValueToDictionary(targetBlackboardKey, weapons[0]);
            Debug.Log("find weapon...");
            Vector3 targetPosition = weapons[0].transform.position;

            if (!agent.TryGetComponent<PlayerMovement>(out var movement))
            {
                return Outcome.FAIL;
            }
            movement.SetDirection(targetPosition);
            movement.MoveToward(targetPosition);

            await Task.Delay(3 * 1000);
            if (!agent.TryGetComponent<IInventory>(out var inventory))
            {
                return Outcome.FAIL;
            }
            weapons[0].GetComponent<IInteractable>().Interact(agent);

            return Outcome.SUCCESS;
        }
    }
}