using Codice.Client.Common.GameUI;
using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public abstract class WanderBaseLeaf : Leaf
{
    private bool timeExpired;
    protected async UniTask<AIEnums> MoveAiAsync(IMover mover, GameObject agent, Vector3 destination)
    {
        bool pathFound;
        NavMeshPath path = new NavMeshPath();
        Vector3 from = agent.transform.position;
        Vector3 to = destination;
        NavMeshHit hit;
        CancellationTokenSource src = new CancellationTokenSource();
        CancellationToken ct = src.Token;

        if (NavMesh.SamplePosition(from, out hit, 10f, NavMesh.AllAreas))
            from = hit.position;
        //else
        //    return AIEnums.FAIL;

        if (NavMesh.SamplePosition(to, out hit, 10f, NavMesh.AllAreas))
            to = hit.position;
        //else
        //    return AIEnums.FAIL;

        pathFound = NavMesh.CalculatePath(from, to, NavMesh.AllAreas, path);
        int cornerRef = 1;
        float approx = 0.05f;
        MoveTimer(src,ct);
        while (CheckDistance(agent.transform.position, to) && pathFound && !timeExpired)
        {
            //Debug.Log($"cornerRef: {cornerRef} | {agent.transform.position} - {path.corners[cornerRef]}");
            if (Mathf.Abs(agent.transform.position.x - path.corners[cornerRef].x) < approx && Mathf.Abs(agent.transform.position.z - path.corners[cornerRef].z) < approx)
                cornerRef++;
            var direction = new Vector3(path.corners[cornerRef].x, 0, path.corners[cornerRef].z);
            var playerPosition2D = new Vector2(agent.transform.position.x, agent.transform.position.z);
            var direction2D = new Vector2(direction.x - playerPosition2D.x, direction.z - playerPosition2D.y);

            mover.MoveToward(direction2D.normalized);
            mover.SetDirection(direction2D.normalized);
            await UniTask.Delay((int)(Time.deltaTime * 1000));
        }
        return AIEnums.SUCCESS;
    }

    private bool CheckDistance(Vector3 agentpos, Vector3 destination)
    {
        var playerGroundPosition = new Vector3(agentpos.x, 0, agentpos.z);
        var destinationGroundPosition = new Vector3(destination.x, 0, destination.z);
        if (Vector3.Distance(playerGroundPosition, destinationGroundPosition) > 1f)
            return true;

        return false;
    }

    private async UniTask MoveTimer(CancellationTokenSource src, CancellationToken ct)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(3));
        ct.ThrowIfCancellationRequested();
        src.Cancel();
    }
}
