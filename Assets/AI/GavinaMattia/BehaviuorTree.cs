using DBGA.AI.Gavina;
using UnityEngine;

public class BehaviuorTree : MonoBehaviour
{ 
	private Selector root;
	private Blackboard blackboard;
	
	void Awake()
	{
		root = transform.GetChild(1).GetComponent<Selector>();
		blackboard = new Blackboard();
	}

	void Update()
	{
		root.Run(gameObject, blackboard);
	}
}
