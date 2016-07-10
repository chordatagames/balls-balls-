using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(PlayerRocket))]
public class PlayerController : MonoBehaviour
{
	private PlayerRocket m_rocket;
	public PlayerRocket rocket
	{
		get
		{
			if(m_rocket == null)
			{
				m_rocket = GetComponent<PlayerRocket>();
			}
			return m_rocket;
		}
	}
	const float defaultCamDistance = 10f;
	public float camDistance = 10;

	void Update()
	{
		
		if(Input.GetKeyDown(KeyCode.Joystick1Button0))
		{
			rocket.Jump();
		}
		camDistance = ( Input.GetAxis("Zoom") + 1 ) * defaultCamDistance;
		
	}

	void FixedUpdate()
	{
		//These movements are based on rigidbody behaviour
		rocket.Rotate(Input.GetAxis("Rotation"));
		rocket.Boost(Input.GetAxis("Gas"));
	}

}
