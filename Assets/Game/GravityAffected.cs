using UnityEngine;


/// <summary>
/// All objects affected by faux-gravity should inherit from this.
/// </summary>
[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class GravityAffected : ScriptedBehaviour
{
	[HideInInspector]
	public Collider2D affectedCollider;
	[HideInInspector]
	public Rigidbody2D mainBody;

	internal virtual void Awake()
	{
		affectedCollider = RequireComponent<Collider2D>();
		mainBody = RequireComponent<Rigidbody2D>();
	}
}
