using Cysharp.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class ForceSuccessDecorator : Decorator
    {
        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            await child.Run(agent, blackboard);
            return true;
        }
    }
}
