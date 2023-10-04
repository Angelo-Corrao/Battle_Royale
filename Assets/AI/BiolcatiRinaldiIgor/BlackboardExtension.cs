using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace DBGA.AI.AI.BiolcatiRinaldiIgor
{
    public static class BlackboardExtension
    {
        public static void SetValueToDictionary<T>(this Dictionary<string, object> blackboard, string key, T value)
        {
            if (!blackboard.ContainsKey(key))
            {
                blackboard.Add(key, value);
                return;
            }

            blackboard[key] = value;
        }

        public static bool TryGetValueFromDictionary<T>(this Dictionary<string, object> blackboard, string key, out T result)
        {
            bool tempResult = blackboard.TryGetValue(key, out object temp);
            result = (T)temp;
            return tempResult;
        }

        public static bool TryGetAtLeastOneTarget<T>(this Dictionary<string, object> blackboard, out T result)
        {
            string targetKey = blackboard.Keys.ToList().Find(k => k[..5] == "Agent");
            bool existTarget = blackboard.TryGetValue(targetKey, out object temp);
            result = (T)temp;
            return existTarget;
        }

    }
}