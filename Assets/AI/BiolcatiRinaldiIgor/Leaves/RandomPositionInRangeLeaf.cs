using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class RandomPositionInRangeLeaf : Leaf
    {
        [SerializeField]
        private string positionBlackboardKey;

        [SerializeField] private float MinRange;
        [SerializeField] private float MaxRange;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            bool foundSafePoint = false;
            Vector3 offset = Vector3.zero;
            while (!foundSafePoint)
            {
                offset = new Vector3(Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)), 0, Random.Range(MinRange, MaxRange) * Mathf.Sign(Random.Range(-1, 1)));
                if (!Physics.CheckSphere(agent.transform.position + offset, 1f, LayerMask.GetMask("Cover")))
                    foundSafePoint = true;
            }
            blackboard.SetValueToDictionary(positionBlackboardKey, agent.transform.position + offset);
            return Outcome.SUCCESS;
        }
    }
}