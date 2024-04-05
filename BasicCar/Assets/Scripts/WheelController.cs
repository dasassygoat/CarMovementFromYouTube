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

    private float currentAcceleration = 0f;
    private float currentBrake = 0f;

    private void FixedUpdate()
    {
        // Get forward/backward acceleration
        if (Input.GetKey(Input.GetAxis("Vertical"))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * acceleration);
        }
    )
}
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
