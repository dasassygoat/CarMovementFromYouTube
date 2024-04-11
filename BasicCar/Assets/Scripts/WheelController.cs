using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider backLeft;

    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform backRightTransform;
    [SerializeField] private Transform backLeftTransform;

    public float acceleration = 500f;
    public float brake = 1000f;
    public float maxTurnAngle = 15;

    private float currentAcceleration = 0f;
    private float currentBrake = 0f;
    private float currentTurnAngle = 0;


    private void FixedUpdate()
    {
        // Get forward/backward acceleration
        currentAcceleration = Input.GetAxis("Vertical") * acceleration;
        currentTurnAngle = Input.GetAxis("Horizontal") * maxTurnAngle; 

        if (Input.GetKey(KeyCode.Space))
        {
            currentBrake = brake;
        }
        else
        {
            currentBrake = 0f;
        }
        
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;
        
        frontRight.brakeTorque = currentBrake;
        frontLeft.brakeTorque = currentBrake;

        frontLeft.steerAngle = currentTurnAngle;
        frontRight.steerAngle = currentTurnAngle;
        
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }
    
    // Update the position and rotation of a wheel collider based on the provided transform.
    void UpdateWheel(WheelCollider col, Transform trans)
    {
        //Get wheel collider state
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);
        
        trans.position = position;
        trans.rotation = rotation;
    }
    
}
