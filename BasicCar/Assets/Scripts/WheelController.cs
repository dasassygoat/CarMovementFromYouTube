using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider backRight;
    [SerializeField] private WheelCollider backLeft;

    public float acceleration = 500f;
    public float brake = 1000f;

    public float currentAcceleration = 0f;
    public float currentBrake = 0f;


    private void FixedUpdate()
    {
        // Get forward/backward acceleration
        currentAcceleration = Input.GetAxis("Vertical") * acceleration;
        //transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * acceleration);

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
    }
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
