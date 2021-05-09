using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController2 : MonoBehaviour
{
    [SerializeField] private Transform com;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float chungusForce;
    [SerializeField] private float chungusDrag;
    [SerializeField] private float chungusNormalDrag;

    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private Vector2 movementInput;
    private Vector2 brakeInput;

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentbreakForce;
    private bool isBreaking;

    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeftWheelCollider;
    [SerializeField] private WheelCollider frontRightWheelCollider;
    [SerializeField] private WheelCollider rearLeftWheelCollider;
    [SerializeField] private WheelCollider rearRightWheelCollider;

    [SerializeField] private Transform frontLeftWheelTransform;
    [SerializeField] private Transform frontRightWheeTransform;
    [SerializeField] private Transform rearLeftWheelTransform;
    [SerializeField] private Transform rearRightWheelTransform;


    public void OnMove(InputAction.CallbackContext ctx)
    {
        movementInput = ctx.ReadValue<Vector2>();


        if (movementInput != Vector2.zero && !GameObject.Find("carsounds").GetComponent<AudioSource>().isPlaying)
        {
            GameObject.Find("carsounds").GetComponent<AudioSource>().Play();
        }

    }

    public void OnBrake(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            isBreaking = true;
        }
        if (ctx.canceled)
        {
            isBreaking = false;
        }
    }


    private void Start() {
        rb.centerOfMass = com.localPosition;    
    }


    private void FixedUpdate()
    {
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        chungus();


    }

    private void chungus()
    {
        if (verticalInput > 0)
        {
            if(horizontalInput > 0){
                rb.AddForce(transform.right*chungusForce*0.25f, ForceMode.Impulse);
            }else if(horizontalInput < 0){
                rb.AddForce(-transform.right*chungusForce*0.25f, ForceMode.Impulse);
            }
            rb.AddForce(transform.forward*(chungusForce), ForceMode.Impulse);
        }
    }



    private void GetInput()
    {
        horizontalInput = movementInput.x;
        verticalInput = movementInput.y;
        //isBreaking = brakeInput.x;

        Debug.Log(brakeInput.ToString());
    }

    private void HandleMotor()
    {
        frontLeftWheelCollider.motorTorque = verticalInput * motorForce;
        frontRightWheelCollider.motorTorque = verticalInput * motorForce;
        currentbreakForce = isBreaking ? breakForce : 0f;
        ApplyBreaking();
    }

    private void ApplyBreaking()
    {

        frontRightWheelCollider.brakeTorque = currentbreakForce;
        frontLeftWheelCollider.brakeTorque = currentbreakForce;
        rearLeftWheelCollider.brakeTorque = currentbreakForce;
        rearRightWheelCollider.brakeTorque = currentbreakForce;

    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeftWheelCollider.steerAngle = currentSteerAngle;
        frontRightWheelCollider.steerAngle = currentSteerAngle;
    }

    private void UpdateWheels()
    {
        UpdateSingleWheel(frontLeftWheelCollider, frontLeftWheelTransform);
        UpdateSingleWheel(frontRightWheelCollider, frontRightWheeTransform);
        UpdateSingleWheel(rearRightWheelCollider, rearRightWheelTransform);
        UpdateSingleWheel(rearLeftWheelCollider, rearLeftWheelTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}