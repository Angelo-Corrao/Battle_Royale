using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    using DBGA.AI.Health;

    [DisallowMultipleComponent]
    public class IsHealthUnderThresholdLeaf : Leaf
    {
        [SerializeField, Range(0f,1f)]
        private float threshold;
        [SerializeField]
        private string percentageRandomShootKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<Health>(out Health health))
                return Outcome.FAIL;

            int maxHealth = health.GetMaxHealth();
            if (health.GetCurrentHealth() < maxHealth * threshold)
            {
                if (blackboard.TryGetValue(percentageRandomShootKey, out var percentage))
                    blackboard.SetValueToDictionary(percentageRandomShootKey, (int)percentage * 2);
                return Outcome.SUCCESS;
            }
            else
                return Outcome.FAIL;

        }
    }
}
