
using Cysharp.Threading.Tasks;
using UnityEngine;


public abstract class Node : MonoBehaviour
{
    public abstract  UniTask<AIEnums> Run(GameObject agent, Blackboard blackboard);
}
