using UnityEngine;
using System.Collections;

public class Car : MonoBehaviour
{
	[System.Serializable]
	public class Wheel
	{
		private Rigidbody2D mainBody { get { return wheel.connectedBody; } }
		private Rigidbody2D m_wheelBody;
		public Rigidbody2D wheelBody
		{
			get
			{
				if(m_wheelBody == null)
				{
					m_wheelBody = wheel.GetComponent<Rigidbody2D>();
				}
				return m_wheelBody;
			}
		}

		
		public WheelJoint2D wheel;
		public bool grounded { get { return isGrounded(); } }

		private bool isGrounded()
		{
			bool g = Physics2D.IsTouchingLayers(wheel.GetComponent<Collider2D>());
			return g;
		}
	}

	public Rigidbody2D mainBody;
	public Wheel backWheels, frontWheels;
	public Transform booster;

	JointMotor2D jointMotor;

	public float totalMass;
	public float jumpForce = 100F;
	public float boostForce = 100F;
	public float rotationSpeed = 10;
	public float maxSpeed = 100f; //The motor speed
	public float maxTorque = 1000f; //The motor speed


	bool facingRight = true;
	float lastJump = 0;

	public void Start()
	{
		jointMotor.maxMotorTorque = maxTorque;
	}

	public void Jump()
	{
		if(backWheels.grounded || frontWheels.grounded)
		{
			backWheels.wheel.GetComponent<Rigidbody2D>().AddForce(mainBody.transform.up * jumpForce);
			frontWheels.wheel.GetComponent<Rigidbody2D>().AddForce(mainBody.transform.up * jumpForce);
		}
	}

	public void Boost()
	{
		Debug.DrawLine(booster.position, booster.position + ( facingRight ? 1 : -1 ) * mainBody.transform.right * boostForce, Color.red);
		mainBody.AddForceAtPosition((facingRight ? 1 : -1) * mainBody.transform.right * boostForce, booster.position);
	}

	public void Drive(float value)
	{
		jointMotor.motorSpeed = ( facingRight ? 1 : -1 ) * value * maxSpeed;
		backWheels.wheel.motor = jointMotor;
	}

	public void Rotate(float value)
	{
		mainBody.AddTorque(value * rotationSpeed);
	}
}
