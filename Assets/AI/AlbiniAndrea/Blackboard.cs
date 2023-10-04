using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class Blackboard
{
    private readonly Dictionary<BlackboardKey, object> blackboard;

    public Blackboard()
    {
        blackboard = new Dictionary<BlackboardKey, object>();
    }

    public void SetValueToDictionary<T>(BlackboardKey key, T value)
    {
        if (!blackboard.ContainsKey(key))
            blackboard.Add(key, value);
        else
            blackboard[key] = value;
    }

    public bool TryGetValueFromDictionary<T>(BlackboardKey key, out T result)
    {
        bool tempResult = blackboard.TryGetValue(key, out object temp);
        result = (T)temp;
        return tempResult;
    }
}

