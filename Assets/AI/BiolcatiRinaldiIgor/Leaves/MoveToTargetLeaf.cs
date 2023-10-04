using DBGA.AI.Movement;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public class MoveToTargetLeaf : Leaf
    {
		[SerializeField]
		private float minSpeed = 0;
		[SerializeField]
		private float maxSpeed = 1;
		[SerializeField, Min(0)]
        private float acceptanceRange;
        [SerializeField]
        private string targetBlackboardKey;
        private NavMeshPath path;

        private void MovePlayer(Vector3 agentPos, Vector3 targetPos, PlayerMovement playerMov)
        {
            Vector3 target;
            Vector2 nextDir;
			int currentIndexCorner = 1;
			NavMesh.CalculatePath(agentPos, targetPos, NavMesh.AllAreas, path);
			if (path.corners.Length > 2)
			{
				if (Vector3.Distance(agentPos, new Vector3(path.corners[currentIndexCorner].x, agentPos.y, path.corners[currentIndexCorner].z)) < acceptanceRange)
					currentIndexCorner++;
				target = new Vector3(path.corners[currentIndexCorner].x, agentPos.y, path.corners[currentIndexCorner].z);
			}
			else
				target = targetPos;
			Vector3 targetDir = (target - agentPos);
			targetDir = targetDir.normalized * Mathf.Clamp(target.magnitude, minSpeed, maxSpeed);
			nextDir = new Vector2(targetDir.x, targetDir.z);
            playerMov.MoveToward(nextDir);
			playerMov.transform.LookAt(target);
		}

        public async override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary(targetBlackboardKey, out GameObject target))
                return Outcome.FAIL;

            if (!agent.TryGetComponent<PlayerMovement>(out var playerMov))
                return Outcome.FAIL;

            Vector3 targetPosition = target.transform.position;
            MovePlayer(agent.transform.position, targetPosition, playerMov);

            while (Vector3.Distance(agent.transform.position, targetPosition) > acceptanceRange)
            {
                targetPosition = target.transform.position;
                MovePlayer(agent.transform.position, targetPosition, playerMov);
                await Task.Delay((int)(Time.fixedDeltaTime * 1000));
            }

            return Outcome.SUCCESS;
        }
    }
}