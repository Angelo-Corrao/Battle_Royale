using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DBGA.AI.Common;

namespace DBGA.AI.AI.LombinoNicolo
{
    public class NL_Pick : MonoBehaviour
    {
        public enum Pick
        {
            weapon,
            ammo,
            armor
        }

        public Pick pick;

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.tag == "Player")
            {
                switch(pick)
                {
                    case Pick.weapon:
                        other.gameObject.GetComponent<IInventory>().PickWeapon(this.GetComponent<IWeapon>());
                        Destroy(this);
                        break;
                        
                }
            }
        }
    }
}
