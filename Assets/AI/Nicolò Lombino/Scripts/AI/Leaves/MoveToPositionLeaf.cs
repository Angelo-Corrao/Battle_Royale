using Codice.CM.Client.Differences.Graphic;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
using DBGA.AI.Movement;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class MoveToPositionLeaf : Leaf
    {
        [SerializeField, Min(0)]
        private float acceptanceRange;
        [SerializeField]
        private string positionBlackboardKey;

        [Header("range of random walk")]
        [SerializeField] private float MinRange;
        [SerializeField] private float MaxRange;
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            Vector3 position = new Vector3(Random.Range(MinRange, MaxRange)
                * Mathf.Sign(Random.Range(-1, 1)), 0, Random.Range(MinRange, MaxRange)
                * Mathf.Sign(Random.Range(-1, 1)));


            if (!agent.TryGetComponent<PlayerMovement>(out var movement))
            {
                return Outcome.FAIL;
            }

            movement.SetDirection(position);
            //while (Vector3.Distance(agent.transform.position, position) > acceptanceRange)
            //{
            //    movement.MoveToward(position);
            //    await Task.Delay(0);
            //}

            Debug.Log("Go To Position SUCCESS");
            return Outcome.SUCCESS;
        }
    }
}