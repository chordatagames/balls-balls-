using UnityEngine;
using System.Collections;

public class PlayerRocket : MonoBehaviour
{


	[SerializeField]
	Collider2D col;

	[SerializeField]
	DistanceJoint2D distJoint;

	public Rigidbody2D mainBody;

	[SerializeField]
	Transform booster;

	public float totalMass;
	public float jumpForce = 100F;
	public float boostForce = 100F;
	public float rotationSpeed = 10;
	public float maxSpeed = 100f; //The motor speed
	public float maxTorque = 1000f; //The motor speed

	bool canCollide = true;
	bool facingRight = true;

	void OnCollisionEnter2D(Collision2D collision)
	{
		if(!canCollide) //ignore collision if just jumped
		{ return; }
		if(collision.gameObject.layer == LayerMask.NameToLayer("Attractor"))
		{
			distJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
			distJoint.enabled = true;
			distJoint.distance = (distJoint.connectedBody.transform.localScale.x + transform.localScale.y) * 0.5f;
		}
	}

	public void Jump()
	{
		if(distJoint.enabled)
		{
			canCollide = false;
			distJoint.enabled = false;
			mainBody.AddForce(Gravity.GeeForce(distJoint.connectedBody.GetComponent<Rigidbody2D>(), mainBody) * jumpForce);
			StartCoroutine(WaitAfterJump(0.1f));
		}
	}

	IEnumerator WaitAfterJump(float waitTime)
	{
		yield return new WaitForSeconds(waitTime);
		canCollide = true;
	}


	public void Boost(float value)
	{
		Debug.DrawLine(booster.position, booster.position + ( facingRight ? 1 : -1 ) * mainBody.transform.right * boostForce, Color.red);
		mainBody.AddForceAtPosition((facingRight ? 1 : -1) * mainBody.transform.right * boostForce * value, booster.position);
	}

	public void Rotate(float value)
	{
		mainBody.AddTorque(value * rotationSpeed);
	}
}
