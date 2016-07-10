using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkedPlayerSetup : NetworkBehaviour
{
	[SerializeField]
	PlayerController player;

	[SerializeField]
	private Camera playerCam;

	void Start()
	{
		if(isLocalPlayer)
		{
			player.enabled = true;
			playerCam.enabled = true;
		}
	}
}
