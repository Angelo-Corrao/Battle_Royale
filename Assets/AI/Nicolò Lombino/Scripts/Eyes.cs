using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

using S = System;
namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class Eyes : MonoBehaviour
    {
        [Range(0f, 360f)]
        public float fov = 120f;
        public float range = 5;

        [SerializeField]
        public string Tag;

        public List<GameObject> GetTargets()
        {
            List<GameObject> targets = new List<GameObject>();
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, range);

            foreach (var e in hitColliders)
            {
                Vector3 directionTarget = (e.transform.position - transform.forward).normalized;
                if (Vector3.Dot(transform.forward, directionTarget) > Mathf.Cos(fov) || e.gameObject.tag != Tag)
                    continue;

                targets.Add(e.gameObject);
            }

            return targets;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            //Gizmos.DrawWireSphere(transform.position, range);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, -fov / 2, 0) * transform.forward * range);
            Gizmos.DrawRay(transform.position, Quaternion.Euler(0, fov / 2, 0) * transform.forward * range);
            Handles.color = Color.blue;
            Handles.DrawWireArc(transform.position, transform.up, Quaternion.Euler(0, -fov / 2, 0) * transform.forward, fov, range);
        }
    }
}

