using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

[RequireComponent(typeof(Car))]
public class PlayerController : MonoBehaviour
{
	private Car m_car;
	public Car car
	{
		get
		{
			if(m_car == null)
			{
				m_car = GetComponent<Car>();
			}
			return m_car;
		}
	}

	void Update()
	{
		car.Drive(Input.GetAxis("Gas")*-1);
		if(Input.GetKeyDown(KeyCode.Joystick1Button0))
		{
			car.Jump();
		}
		
	}

	void FixedUpdate()
	{
		//These movements are based on rigidbody behaviour
		car.Rotate(Input.GetAxis("Rotation") * -1);
		if(Input.GetKey(KeyCode.Joystick1Button1))
		{
			car.Boost();
		}
	}

}
