

using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;
namespace DBGA.AI.AI.FortiAndrea
{
    public class MoveToTargetLeaf : Leaf
    {
        [SerializeField, Min(0)]
        private float acceptanceRange;
        [SerializeField]
        private string targetBlackboardKey;
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary(targetBlackboardKey, out GameObject target))
            {
                return Outcome.FAIL;
            }

            if (!agent.TryGetComponent<NavMeshAgent>(out var navMeshAgent))
            {
                return Outcome.FAIL;
            }

            Vector3 targetPosition = target.transform.position;
            navMeshAgent.isStopped = false;

            while (Vector3.Distance(agent.transform.position, targetPosition) > acceptanceRange)
            {
                targetPosition = target.transform.position;
                navMeshAgent.SetDestination(targetPosition);
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }

            navMeshAgent.isStopped = true;
            return Outcome.SUCCESS;
        }
    }
}