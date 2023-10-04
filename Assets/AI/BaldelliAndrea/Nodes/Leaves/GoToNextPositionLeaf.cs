using Cysharp.Threading.Tasks;
using DBGA.AI.Common;
using DBGA.AI.Sensors;
using UnityEngine;
using UnityEngine.AI;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public class GoToNextPositionLeaf : Leaf
    {
        [SerializeField]
        private float stopDistance = 0.2f;
        [SerializeField]
        private float maxMoveTime = 2f;

        public override async UniTask<bool> Run(GameObject agent, Blackboard blackboard)
        {
            if (!blackboard.TryGetValueFromDictionary<Vector3>(BlackboardKey.NEXT_POSITION, out Vector3 nextPosition))
                return false;
            if (!agent.TryGetComponent<IMover>(out IMover mover))
                return false;

            float startTime = Time.time;

            NavMeshPath path = new();
            bool result = NavMesh.CalculatePath(agent.transform.position, nextPosition, NavMesh.AllAreas, path);
            nextPosition = result && path.corners.Length > 1 ? path.corners[1] : nextPosition;

            nextPosition.y = agent.transform.position.y;

            while(Vector3.Distance(agent.transform.position, nextPosition) >= stopDistance &&
                Time.time - startTime <= maxMoveTime)
            {
                var direction = (nextPosition - agent.transform.position).normalized;
                var direction2d = new Vector2(direction.x, direction.z);
                mover.MoveToward(direction2d);
                mover.SetDirection(direction2d);
                await UniTask.DelayFrame(1);
            }

            return true;
        }
    }
}
