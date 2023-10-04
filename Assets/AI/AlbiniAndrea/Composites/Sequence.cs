using Cysharp.Threading.Tasks;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[DisallowMultipleComponent]
public class Sequence : Composite
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        foreach (var child in children)
            if (await child.Run(agent, blackboard) == AIEnums.FAIL)
                return AIEnums.FAIL;

        return AIEnums.SUCCESS;
    }
}
