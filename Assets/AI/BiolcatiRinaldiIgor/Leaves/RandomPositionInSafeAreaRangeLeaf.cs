using DBGA.AI.Common;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class RandomPositionInSafeAreaRangeLeaf : Leaf
    {
        [SerializeField]
        private string stormKey;
        [SerializeField]
        private string positionBlackboardKey;
        private float minRange;
        private float maxRange;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetValue(stormKey, out var storm))
                return Outcome.FAIL;

            bool foundSafePoint = false;
            Vector3 offset = Vector3.zero;
            Vector3 safePos = (storm as IStorm).GetCenter();
            safePos = new Vector3(safePos.x, agent.transform.position.y, safePos.z);
            minRange = (storm as IStorm).GetRadius() / 2;
            maxRange = (storm as IStorm).GetRadius() * 0.9f;
            while (!foundSafePoint)
            {
                offset = new Vector3(Random.Range(minRange, maxRange) * Mathf.Sign(Random.Range(-1, 1)), 0,
                    Random.Range(minRange, maxRange) * Mathf.Sign(Random.Range(-1, 1)));
                if (!Physics.CheckSphere(safePos + offset, 1f, LayerMask.GetMask("Cover")))
                    foundSafePoint = true;
            }
            blackboard.SetValueToDictionary(positionBlackboardKey, safePos + offset);
            return Outcome.SUCCESS;
        }
    }
}