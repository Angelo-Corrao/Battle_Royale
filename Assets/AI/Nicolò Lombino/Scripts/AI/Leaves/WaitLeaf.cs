using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class WaitLeaf : Leaf
    {
        [SerializeField, Min(0)]
        private float waitTime;
        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            await Task.Delay((int)(waitTime * 1000));
            return Outcome.SUCCESS;
        }
    }
}
