using UnityEngine;
using UnityEngine.Networking;
public class PlayerFollower : MonoBehaviour
{

	[Tooltip("The player to follow")]
	public PlayerController player;
	public float camDistance = 10;

	void LateUpdate ()
	{
		Vector3 target = player.car.mainBody.transform.position;
		target += Vector3.back * camDistance * 10;
		transform.position = target;
	}
}
