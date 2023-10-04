using DBGA.AI.Common;
using UnityEngine;

namespace DBGA.AI.Pickable
{
    using DBGA.AI.DamageWrapper;

    public class ArmorPicker : MonoBehaviour, IInteractable
    {
        private const string PLAYERTAG = "Player";

        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private Collider armorCollider;
        [SerializeField]
        private Collider armorTrigger;
        [SerializeField]
        private Renderer mesh;

        private IArmor armor;
        private DamageWrapper armorDamageWrapper;

        void Awake()
        {
            armor = GetComponent<IArmor>();
        }

        private void Pick(GameObject target)
        {
            armorTrigger.enabled = false;
            transform.parent = target.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.identity;
        }

        public void Interact(GameObject obj)
        {
            if (obj.TryGetComponent<IInventory>(out var inventory))
            {
                inventory?.PickArmor(armor);
                armorDamageWrapper?.AddDamagable(armor);
                Pick(obj);
            }
        }
    }
}
