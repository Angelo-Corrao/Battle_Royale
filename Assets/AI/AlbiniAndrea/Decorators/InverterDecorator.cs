using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverterDecorator : Decorator
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {

        AIEnums childReturnType = await child.Run(agent, blackboard);
       if (childReturnType == AIEnums.SUCCESS)
            return AIEnums.FAIL;

        if (childReturnType == AIEnums.SUCCESS)
            return AIEnums.SUCCESS;

        return childReturnType;
    }
}
