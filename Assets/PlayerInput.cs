using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
	public float Acceleration {
	get {
		return m_Acceleration;
		}
	}

	public float Steering {
		get {
			return m_Steering;
		}
	}

	float m_Acceleration;
	float m_Steering; 

	//bool m_FixedUpdateHappened;

	//define variables
	private bool accelerating = false;
	private bool turningLeft = false;
	private bool turningRight = false;
	private bool reverseGear = false;

	public float wheelDampening;

	void Update() {

		GetPlayerInput();
		if (reverseGear) { //if reverse activated
			if (accelerating) { //do the normal driving
			m_Acceleration = -10f; //10f
			wheelDampening = 500f; 
		}else  {
			m_Acceleration = 0f;
			wheelDampening = 500000f; 
			} 
		} else {
			if (accelerating) { //do the normal driving
			m_Acceleration = 100f; //10f
			wheelDampening = 500f; 
		}else  {
			m_Acceleration = 0f;
			wheelDampening = 500000f; 
			} 
		}
		

		if (turningLeft) {
			m_Steering = -1f;
		} else if (!turningLeft && turningRight) {
			m_Steering = 1f;
		} else {
			m_Steering = 0f;
		}

	}

	private void GetPlayerInput() {
		//accelerating
		
		
		if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))  //PrimaryIndexTrigger
		{
			accelerating = true;
		}
		if (OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch))
		{
			accelerating = false;
		}

	//	Debug.Log("Currently: " + accelerating);

		//detect button b

		if (OVRInput.GetDown(OVRInput.Button.Two, OVRInput.Controller.RTouch)) 
		{
		//	Debug.Log("B button pressed!");
			if (reverseGear) {
				reverseGear = false;
			} else {
				reverseGear = true;
			}
		}
		
		
		//smaller primary trigger right
		if (OVRInput.GetDown(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch)) //PrimaryThumbstickDown
		{
			
		//	use later for grabbing stuff
		}
		if (OVRInput.GetUp(OVRInput.Button.PrimaryHandTrigger, OVRInput.Controller.RTouch))
		{
			
		//	use later for grabbing stuff
		}

		//turning left
		if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
		{
			turningLeft = true;
		}
		if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickLeft, OVRInput.Controller.RTouch))
		{
			turningLeft = false;
		}

		//turning right
		if (OVRInput.GetDown(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
		{
			turningRight = true;
		}
		if (OVRInput.GetUp(OVRInput.Button.PrimaryThumbstickRight, OVRInput.Controller.RTouch))
		{
			turningRight = false;
		}

	}


}

