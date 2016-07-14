using UnityEngine;
using System;

public static class ExtensionMethods
{
	public static T RequireComponent<T>(this MonoBehaviour behaviour, Action<T> setup) where T : Component
	{
		T component = behaviour.GetComponent<T>();
		if(component == null) { component = behaviour.gameObject.AddComponent<T>(); }
		setup(component);
		return component;
	}
}