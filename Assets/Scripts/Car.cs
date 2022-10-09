using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyRacingInput;

public class Car : MonoBehaviour
{
    [SerializeField] float motorTorque = 100f;
    [SerializeField] float maxSteer = 30f;

    [SerializeField] Transform centreOfMass;

    [SerializeField] float Steer { get; set; }
    [SerializeField] float Throttle { get; set; }

    Rigidbody carRB;

    [SerializeField] InputManager inputManager;

    private Wheel[] wheels;

    private void Start()
    {
        wheels = GetComponentsInChildren<Wheel>();
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = centreOfMass.localPosition;
    }

    void Update()
    {
        Steer = inputManager.Turn;
        Throttle = inputManager.Move;

        foreach(var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
