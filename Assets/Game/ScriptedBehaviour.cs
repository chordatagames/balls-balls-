using UnityEngine;
using System;
/// <summary>
/// All scripted behaviour that needs access to internal components should inherit from this.
/// </summary>
public abstract class ScriptedBehaviour : MonoBehaviour
{
	/// <summary>
	/// Requires a component from the gameobject currently beeing scripted
	/// without the need for constant use of GetComponent or messy inspectors
	/// using multiple [SerializeField]-attributes.
	/// 
	/// Called in Awake()
	/// </summary>
	public T RequireComponent<T>() where T : Component
	{
		T component = gameObject.GetComponent<T>();
		if(component == null) { component = gameObject.AddComponent<T>(); }
		return component;
	}

	/// <summary>
	/// Require a component with a specific setup, e.g. change the component properties
	/// </summary>
	public T RequireComponent<T>(Action<T> setup) where T : Component
	{
		T component = gameObject.GetComponent<T>();
		if(component == null) { component = gameObject.AddComponent<T>(); }
		setup(component);
		return component;
	}

	/// <summary>
	/// Requires a component from a gameobject
	/// Called in Awake()
	/// </summary>
	public static T RequireComponentInOther<T>(GameObject other) where T : Component
	{
		T component = other.GetComponent<T>();
		if(component == null) { component = other.AddComponent<T>(); }
		return component;
	}

	/// <summary>
	/// Require a component with a specific setup, e.g. change the component properties
	/// </summary>
	public static T RequireComponentInOther<T>(GameObject other, Action<T> setup) where T : Component
	{
		T component = other.GetComponent<T>();
		if(component == null) { component = other.AddComponent<T>(); }
		setup(component);
		return component;
	}
}
