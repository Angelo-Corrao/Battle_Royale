using DBGA.AI.Common;
using DBGA.AI.Pickable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.AIs.CorraoAngelo
{
    public class PickWeapon : Node
    {
		private Picker picker;

        public PickWeapon(Picker picker, ref BlackBoard blackboard) {
            this.picker = picker;
            this.blackboard = blackboard;
        }

		public override NodeState Evaluate() {
			if (blackboard.TryGetValueFromDictionary("isAnyNodeRunning", out bool isAnyNodeRunning)) {
				if (isAnyNodeRunning) {
					if (nodeState != NodeState.RUNNING) {
						nodeState = NodeState.DEFAULT;
						return nodeState;
					}
				}
			}

			picker.Pick();

            nodeState = NodeState.SUCCESS;
            return nodeState;
		}
	}
}
