using DBGA.AI.Movement;
using DBGA.AI.Pickable;
using DBGA.AI.Sensors;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DBGA.AI.AIs.CorraoAngelo
{
	public class CorraoAgent : BehaviorTree {
		public Storm.Storm storm;
		private PlayerMovement playerMovement;
		private Inventory.Inventory inventory;
		private Picker picker;

		private EyesSensor eyeSensor;
		private PickableSensor pickableSensor;

		private void Awake() {
			storm = FindObjectOfType<Storm.Storm>();
			playerMovement = GetComponent<PlayerMovement>();
			inventory = GetComponent<Inventory.Inventory>();
			picker = GetComponent<Picker>();

			eyeSensor = GetComponent<EyesSensor>();
			pickableSensor = GetComponent<PickableSensor>();
		}

        protected override Node SetUpTree() {
			// Leaves
			var aim = new Aim(playerMovement, ref blackboard);
			var getTarget = new GetTarget(eyeSensor, ref blackboard);
			var getWeapon = new GetWeapon(pickableSensor, ref blackboard);
			var moveToDirection = new MoveToDirection(playerMovement, 5, ref blackboard);
			var moveToPosition = new MoveToPosition(playerMovement, ref blackboard);
			var pickWeapon = new PickWeapon(picker, ref blackboard);
			var reload = new Reload(inventory, ref blackboard);
			var shoot = new Shoot(inventory, ref blackboard);
			var swapWeapon = new SwapWeapon(inventory, ref blackboard);

			//var aimMoveToPosSequence = new Sequence(new List<Node> { aim, moveToPosition }, ref blackboard);
			//var aimMoveToDirectionSequence = new Sequence(new List<Node> { aim, moveToDirection }, ref blackboard);

			// Break Conditions
			var stormCondition = new IsInStormCondition(moveToPosition, storm, ref blackboard);
			var targetCondition = new GetTargetCondition(eyeSensor, ref blackboard);
			var weaponCondition = new GetWeaponCondition(pickableSensor, ref blackboard);

			var outOfAmmoReload = new OutOfAmmo(reload, inventory, ref blackboard);
			var alwaysSucceedOutOfAmmo = new AlwaysSucceded(outOfAmmoReload, ref blackboard);
			var getWeaponSequence = new Sequence(new List<Node> { getWeapon, moveToPosition, pickWeapon }, ref blackboard);

			var aimAndShootSequence = new Sequence(new List<Node> { aim, shoot }, ref blackboard);
			var outOfAmmoAimAndShoot = new OutOfAmmo(aimAndShootSequence, inventory, ref blackboard);
			var inverterOutOfAmmo = new Inverter(outOfAmmoAimAndShoot, ref blackboard);
			var isRifleEquipped = new IsRifleEquipped(swapWeapon, inventory, ref blackboard);
			var inverterIsRifleEquipped = new Inverter(isRifleEquipped, ref blackboard);
			var alwaysSucceedIsRifleEquipped = new AlwaysSucceded(isRifleEquipped, ref blackboard);
			var isEnemyCloseIsRifleEquipped = new IsEnemyClose(alwaysSucceedIsRifleEquipped, ref blackboard);
			var isEnemyCloseSelector = new Selector(new List<Node> { isEnemyCloseIsRifleEquipped, inverterIsRifleEquipped }, ref blackboard);
			var alwaysSucceedIsEnemyCloseSelector = new AlwaysSucceded(isEnemyCloseSelector, ref blackboard);
			var killEnemySequence = new Sequence(new List<Node> { alwaysSucceedIsEnemyCloseSelector, inverterOutOfAmmo}, ref blackboard);
			var haveWeaponKillEnemySequence = new HaveWeapon(killEnemySequence, inventory, ref blackboard);
			// Change aim with haveWeaponKillEnemySequence when all features will be implemented
			var targetSequence = new Sequence(new List<Node> { getTarget, aim, shoot }, ref blackboard);

			var isInTheStorm = new IsInTheStorm(moveToPosition, storm, ref blackboard);

			var findWeaponSelector = new Selector(new List<Node> { getWeaponSequence, moveToDirection }, ref blackboard, new List<Node> { weaponCondition });
			var haveEmptySlots = new HaveEmptySlots(findWeaponSelector, inventory, ref blackboard);
			var wanderSequence = new Sequence(new List<Node> { alwaysSucceedOutOfAmmo, moveToDirection }, ref blackboard, new List<Node> { weaponCondition });
			var neutralSelector = new Sequence(new List<Node> { haveEmptySlots, wanderSequence }, ref blackboard, new List<Node> { stormCondition, targetCondition });

			return new Selector(new List<Node> { isInTheStorm, targetSequence, neutralSelector }, ref blackboard);
			//return getWeaponSequence;
		}

		protected override void SetUpBlackboard() {
			blackboard.SetValueToDictionary("agent", this);
			blackboard.SetValueToDictionary("isAnyNodeRunning", false);
			blackboard.SetValueToDictionary("hasToStop", false);
			blackboard.SetValueToDictionary("hittedObstacle", false);
			blackboard.SetValueToDictionary("dirToLook", Vector2.zero);
		}

		private void OnControllerColliderHit(ControllerColliderHit hit) {
			if (hit.gameObject.CompareTag("Obstacles")) {
				blackboard.SetValueToDictionary("hittedObstacle", true);
				blackboard.SetValueToDictionary("hasToStop", true);
			}
		}
	}
}
