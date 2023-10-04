using Cysharp.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    [DisallowMultipleComponent]
    public class BehaviourTree : MonoBehaviour
    {
        [SerializeField]
        private Node root;
        [SerializeField]
        private GameObject agent;

        private Blackboard blackboard;
        private bool shouldStart;

        void Awake()
        {
            blackboard = new Blackboard();
            shouldStart = true;
        }

        void Update()
        {
            if (!root || !shouldStart || !agent)
                return;

            _ = RunTree();
        }

        private async UniTask<bool> RunTree()
        {
            shouldStart = false;
            bool result = await root.Run(agent, blackboard);
            shouldStart = true;
            return result;
        }
    }
}
