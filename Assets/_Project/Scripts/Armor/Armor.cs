using DBGA.AI.Common;
using UnityEngine;

namespace DBGA.AI.Armor
{
    public class Armor : MonoBehaviour, IArmor
    {
        [SerializeField]
        private int maxDurability;
        [SerializeField]
        private int priority;
        [SerializeField]
        private Rigidbody rb;
        [SerializeField]
        private Collider armorCollider;
        [SerializeField]
        private Collider armorTrigger;

        private int currentDurability;

        void Awake()
        {
            currentDurability = maxDurability;
        }

        public int GetCurrentDurability()
        {
            return currentDurability;
        }

        public int GetPriority()
        {
            return priority;
        }

        public int TakeDamage(int damage)
        {
            int exceedDamage = 0;
            if (currentDurability <= damage)
            {
                exceedDamage = damage - currentDurability;
                currentDurability = 0;
            }
            else
                currentDurability -= damage;
            return exceedDamage;
        }

        public void Drop()
        {
            transform.position += Vector3.up + Vector3.forward;
            /*rb.useGravity = true;
            armorCollider.enabled = true;*/
            armorTrigger.enabled = true;
            transform.SetParent(null);
        }
    }
}
