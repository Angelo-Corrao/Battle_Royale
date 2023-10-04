using Cysharp.Threading.Tasks;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImINStormDecorator : Decorator
{
    public override async UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard)
    {
        if (!agent.TryGetComponent<StormSensor>(out StormSensor stormSensor))
            return AIEnums.FAIL;
        var storm = stormSensor.GetStorm();

        if (ImInRange(agent.transform.position,storm.GetCenter(),storm.GetRadius()))
            return AIEnums.FAIL;

        if (storm.GetRadius() <= 0)
            return AIEnums.FAIL;

        return await child.Run(agent, blackboard);
    }

    private bool ImInRange(Vector3 myPosition,Vector3 StormPosition,float stormRadious)
    {
       if(myPosition.x<StormPosition.x+stormRadious && myPosition.x > StormPosition.x - stormRadious)
            if (myPosition.z < StormPosition.z + stormRadious && myPosition.z > StormPosition.z - stormRadious)
                return true;

       return false;
    }
}
