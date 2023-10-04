using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
    public abstract class Node : MonoBehaviour
    {
        public abstract Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard);
    }
}
