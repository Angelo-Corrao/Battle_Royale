
using System.Collections.Generic;
using UnityEngine;

    public abstract class Composite : Node
    {
        protected List<Node> children;

        void Awake()
        {
            children = new List<Node>();
            for(int i = 0;i<transform.childCount;i++)
                if (transform.GetChild(i).gameObject.TryGetComponent<Node>(out var childNode))
                    children.Add(childNode);
        }
    }

