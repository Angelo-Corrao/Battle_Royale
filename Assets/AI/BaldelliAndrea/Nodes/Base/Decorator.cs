using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public abstract class Decorator : Node
    {
        protected Node child;

        void Awake()
        {
            if (transform.childCount <= 0)
                return;

            if (!transform.GetChild(0).TryGetComponent<Node>(out var childNode))
                return;

            child = childNode;
        }
    }
}
