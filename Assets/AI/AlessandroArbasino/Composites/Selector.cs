using Cysharp.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

    [DisallowMultipleComponent]
    public class Selector: Composite
    {
        public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
        {
            foreach (var child in children)
                if (await child.Run(agent, blackboard)==AIEnums.SUCCESS)
                    return AIEnums.SUCCESS;

            return AIEnums.FAIL;
        }
    }

