using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyRacingInput;
using Unity.Netcode;

public class Car : NetworkBehaviour
{
    [Header("Car Tune")]
    [SerializeField] float motorTorque = 100f;
    [SerializeField] float maxSteer = 30f;

    [Header("Physics")]
    [SerializeField] Transform centreOfMass;

    [Header("Input")]
    [SerializeField] InputManager inputManager;

    [Header("Camera")]
    [SerializeField] GameObject vm_cam;

    private float Steer { get; set; }
    private float Throttle { get; set; }

    private Rigidbody carRB;
    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = centreOfMass.localPosition;

        if(!IsOwner)
        {
            Destroy(vm_cam);
        }
    }

    void Update()
    {
        if (!IsOwner) return;

        Steer = inputManager.Turn;
        Throttle = inputManager.Move;

        foreach(var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
