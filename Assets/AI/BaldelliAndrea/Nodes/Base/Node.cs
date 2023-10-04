using UnityEngine;
using Cysharp.Threading.Tasks;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public abstract class Node : MonoBehaviour
    {
        public abstract UniTask<bool> Run(GameObject agent, Blackboard blackboard);
    }
}
