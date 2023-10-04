using DBGA.AI.Movement;
using DBGA.AI.PlayerController;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class MoveToPositionLeaf : Leaf
    {
        private float minSpeed = 0;
        private float maxSpeed = 1;
        [SerializeField, Min(0)]
        private float acceptanceRange;
        [SerializeField]
        private string positionBlackboardKey;
        private NavMeshPath path;

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary(positionBlackboardKey, out Vector3 targetPosition))
                return Outcome.FAIL;

            if (!agent.TryGetComponent<PlayerMovement>(out var playerMov))
                return Outcome.FAIL;

            path = new NavMeshPath();
            Vector2 nextDir;
            while (Vector3.Distance(agent.transform.position, targetPosition) > acceptanceRange)
            {
                int currentIndexCorner = 1;
                NavMesh.CalculatePath(agent.transform.position, targetPosition, NavMesh.AllAreas, path);
                Vector3 target;
                if (path.corners.Length > 2)
                {
                    if(Vector3.Distance(agent.transform.position, new Vector3(path.corners[currentIndexCorner].x, agent.transform.position.y, path.corners[currentIndexCorner].z)) < acceptanceRange)
                        currentIndexCorner++;
                    target = new Vector3(path.corners[currentIndexCorner].x, agent.transform.position.y, path.corners[currentIndexCorner].z);
                }
                else
                    target = targetPosition;
                Vector3 targetDir = (target - agent.transform.position);
                targetDir = targetDir.normalized * Mathf.Clamp(target.magnitude,minSpeed,maxSpeed);
                nextDir = new Vector2(targetDir.x, targetDir.z);
                playerMov.MoveToward(nextDir);
				playerMov.transform.LookAt(target);
				await Task.Delay((int)(Time.fixedDeltaTime * 1000));
			}
            return Outcome.SUCCESS;
        }
    }
}