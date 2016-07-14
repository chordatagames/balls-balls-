using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour
{
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



	void Awake()
	{
		this.RequireComponent<Rigidbody2D>(r => r.mass = 100);
	}
	//internal override void Awake()
	//{
	//	base.Awake();
	//}
}
