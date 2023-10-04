using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class SelectorComposite : Composite
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            foreach (var child in children)
                if (await child.Run(agent, blackboard))
                    return true;

            return false;
        }
    }
}
