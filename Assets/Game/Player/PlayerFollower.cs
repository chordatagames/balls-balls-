using UnityEngine;
using UnityEngine.Networking;
public class PlayerFollower : MonoBehaviour
{

	[Tooltip("The player to follow")]
	public PlayerController player;
	

	void LateUpdate ()
	{
		Vector3 target = player.rocket.mainBody.transform.position;
		target += Vector3.back * player.camDistance * 10;
		transform.position = target;
		transform.rotation = Quaternion.identity;
	}
}
