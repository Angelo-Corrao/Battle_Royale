using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
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