using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.AIs.CorraoAngelo
{
    public abstract class BehaviorTree : MonoBehaviour
    {
        private Node root;
		protected BlackBoard blackboard = new BlackBoard();

		protected void Start() {
            root = SetUpTree();
            SetUpBlackboard();
        }

		private void Update() {
            /*if(blackboard.TryGetValueFromDictionary("isAnyNodeRunning", out bool result)) {
                Debug.Log(result);
            }*/

			if (root != null)
                root.Evaluate();
		}

		protected abstract Node SetUpTree();

        protected abstract void SetUpBlackboard();
    }
}
