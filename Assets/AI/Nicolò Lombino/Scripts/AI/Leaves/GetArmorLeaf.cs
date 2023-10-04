using DBGA.AI.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using DBGA.AI.Sensors;
using DBGA.AI.Movement;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class GetArmorLeaf : Leaf
    {
        [SerializeField, Min(0)]
        private float acceptanceRange;

        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            Debug.Log("searching armor...");

            if (!agent.TryGetComponent<PickableSensor>(out var eyes))
            {
                return Outcome.FAIL;
            }

            List<GameObject> armors = new List<GameObject>();
            armors = eyes.GetNearArmors();

            if (armors.Count <= 0)
            {
                return Outcome.FAIL;
            }

            blackboard.SetValueToDictionary(targetBlackboardKey, armors[0]);
            Debug.Log("find armor...");
            Vector3 targetPosition = armors[0].transform.position;

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
            armors[0].GetComponent<IInteractable>().Interact(agent);

            return Outcome.SUCCESS;
        }


    }
}