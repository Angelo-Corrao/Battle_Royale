using UnityEngine;
namespace DBGA.AI.AI.FortiAndrea
{
    [DisallowMultipleComponent]
    public abstract class Decorator : Node
    {
        public Node child;

        private void Awake()
        {
            if (transform.childCount <= 0)
            {
                return;
            }

            if (!transform.GetChild(0).TryGetComponent<Node>(out var childNode))
            {
                return;
            }

            child = childNode;
        }
    }
}