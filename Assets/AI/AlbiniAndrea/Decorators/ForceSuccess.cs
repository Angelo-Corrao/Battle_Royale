using Cysharp.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

    [DisallowMultipleComponent]
    public class ForceSuccessDecorator : Decorator
    {
        public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
        {
            await child.Run(agent, blackboard);
            return AIEnums.SUCCESS;
        }
    }
