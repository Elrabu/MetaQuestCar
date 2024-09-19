using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{


    private PlayerInput inputManager;
    public List<WheelCollider> throttleWheels;
    public List<WheelCollider> steeringWheels;
    public float strengthCoefficient = 2000f;
    public float maxTurn = 90f;

    // Start is called before the first frame update
    void Start()
    {
        inputManager = GetComponent<PlayerInput>();
        
    }

    
    void FixedUpdate()
    {
        float motorTorque = inputManager.Acceleration * strengthCoefficient;

        foreach (WheelCollider wheel in throttleWheels)
        {           
           // wheel.motorTorque = 1000000 * strengthCoefficient * Time.deltaTime * inputManager.Acceleration; 
            wheel.wheelDampingRate = inputManager.wheelDampening;
             wheel.motorTorque = motorTorque;
        }

        foreach (WheelCollider wheel in steeringWheels)
        {
           // wheel.motorTorque = 1000000 * strengthCoefficient * Time.deltaTime * inputManager.Acceleration; 
            wheel.steerAngle = maxTurn * inputManager.Steering;
            wheel.wheelDampingRate = inputManager.wheelDampening;
            wheel.motorTorque = motorTorque;
        }
    }
}