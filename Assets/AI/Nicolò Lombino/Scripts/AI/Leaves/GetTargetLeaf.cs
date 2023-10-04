using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using DBGA.AI.Sensors;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class GetTargetLeaf : Leaf
    {
        [SerializeField]
        private string targetBlackboardKey;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!agent.TryGetComponent<EyesSensor>(out var eyes))
            {
                return Outcome.FAIL;
            }

            List<GameObject> enemies = new List<GameObject>();
            enemies = eyes.GetEnemiesTargets();
            
            if (enemies.Count <= 0)
            {
                return Outcome.FAIL;
            }

            blackboard.SetValueToDictionary(targetBlackboardKey, enemies[0]);
            agent.transform.LookAt((enemies[0].transform.position - agent.transform.position).normalized);
            //float rndRot = Random.RandomRange(-10, 10);
            //agent.transform.eulerAngles += new Vector3(0, rndRot, 0);
            return Outcome.SUCCESS;
        }
    }
}