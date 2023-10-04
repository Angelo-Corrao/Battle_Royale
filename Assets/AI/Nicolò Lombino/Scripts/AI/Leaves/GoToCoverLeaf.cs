using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

using S = System;

namespace DBGA.AI.AI.LombinoNicolo
{
    [DisallowMultipleComponent]
    public class GoToCoverLeaf : Leaf
    {
        public override Task<Outcome> Run(GameObject agent, Dictionary<string, object> blackboard)
        {
            throw new S.NotImplementedException();
        }
    }
}
