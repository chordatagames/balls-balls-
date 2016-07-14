using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(PlayerRocket))]
public class PlayerController : ScriptedBehaviour
{
	[HideInInspector]
	public PlayerRocket rocket;

	const float defaultCamDistance = 10f;
	public float camDistance = 10;

	void Awake()
	{
		rocket = RequireComponent<PlayerRocket>();
	}

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
