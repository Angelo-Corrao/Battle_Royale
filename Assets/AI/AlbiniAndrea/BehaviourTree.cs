
using System.Collections.Generic;
using UnityEngine;


public class BehaviourTree : MonoBehaviour
{
    private Blackboard blackboard;
    private Node root;

    private bool shouldStart = true;

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

        root = childNode; ;

        blackboard = new Blackboard();
    }

    private void Update()
    {
        if (!root || !shouldStart)
        {
            return;
        }

        RunTree();
    }

    private async void RunTree()
    {
       
        shouldStart = false;
        await root.Run(transform.parent.gameObject, blackboard);
        shouldStart = true;
    }
}
