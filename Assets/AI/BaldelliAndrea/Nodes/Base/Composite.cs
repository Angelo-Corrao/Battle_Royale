using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.AI.BaldelliAndrea
{
    public abstract class Composite : Node
    {
        protected List<Node> children;

        void Awake()
        {
            children = new List<Node>();
            foreach (Transform child in transform)
                if (child.gameObject.TryGetComponent<Node>(out var childNode))
                    children.Add(childNode);
        }
    }
}
