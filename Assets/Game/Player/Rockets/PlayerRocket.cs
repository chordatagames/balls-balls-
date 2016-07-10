using UnityEngine;
using System.Collections;

public class PlayerRocket : MonoBehaviour
{
	private bool isGrounded()
	{
		return Physics2D.IsTouchingLayers(col);
	}



	[SerializeField]
	Collider2D col;
	
	public Rigidbody2D mainBody;

	[SerializeField]
	Transform booster;

	public float totalMass;
	public float jumpForce = 100F;
	public float boostForce = 100F;
	public float rotationSpeed = 10;
	public float maxSpeed = 100f; //The motor speed
	public float maxTorque = 1000f; //The motor speed


	bool facingRight = true;

	public void Jump()
	{
		if(isGrounded())
		{
			mainBody.AddForce(mainBody.transform.up * jumpForce); //TODO Get the "real up" based on the normal of the touched object.
		}
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
