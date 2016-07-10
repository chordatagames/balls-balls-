using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(Rigidbody2D))]
public class Gravity : MonoBehaviour {

	public static float G = 1F;
	public static List<Gravity> attractors = new List<Gravity>();

	public float radiusSOI { get { return rigid.mass * 0.25f; } set { rigid.mass = ( value / 0.25f ); } }//Yep that's gravitys SOI for yall

	private Rigidbody2D m_rigid;
	public Rigidbody2D rigid
	{
		get
		{
			if(m_rigid == null)
			{
				m_rigid = GetComponent<Rigidbody2D>();
			}
			return m_rigid;
		}
	}
	
	void Start()
	{
		attractors.Add(this);
	}

	private Collider2D[] affectedColliders;
		
	void FixedUpdate()
	{
		affectedColliders = Physics2D.OverlapCircleAll(transform.position, radiusSOI, ~(1<<8)); //attract all but attractors
		foreach (Collider2D col in affectedColliders)
		{
			if(col.attachedRigidbody != null)
			{
				col.attachedRigidbody.AddForce(GeeForce(col.attachedRigidbody, rigid));
			}
		}
	}

	public static Vector2 GeeForceDirection(Rigidbody2D m, Rigidbody2D M)
	{
		return ( M.transform.position - m.transform.position ).normalized;
	}

	public static Vector2 GeeForce(Rigidbody2D m, Rigidbody2D M) 
	{
		float gSize = ( G * m.mass * M.mass ) / ( Vector3.Distance(m.transform.position, M.transform.position) );
		return gSize * GeeForceDirection(m, M);
	}

	void OnDrawGizmos()
	{
		//Gizmos.DrawWireSphere(rigid.transform.position, radiusSOI);
	}
}
