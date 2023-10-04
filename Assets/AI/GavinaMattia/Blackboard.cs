using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackboard
{
	public Dictionary<string,object> blackboard;

	public Blackboard() 
	{
		blackboard = new Dictionary<string,object>();
	}

	public void SetBlackboardValue(string key, object value) 
	{
		if (!blackboard.ContainsKey(key))
			blackboard.Add(key, value);
		else
			blackboard[key] = value;
	}

	public object GetBlackboardValue(string key) 
	{
		if (blackboard.TryGetValue(key, out object value))
			return value;
		return null;
	}
}
