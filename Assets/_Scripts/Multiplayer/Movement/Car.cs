using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyRacingInput;
using Photon.Pun;

public class Car : MonoBehaviour
{
    [Header("Car Tune")]
    [SerializeField] float motorTorque = 100f;
    [SerializeField] float maxSteer = 30f;

    [Header("Physics")]
    [SerializeField] Transform centreOfMass;

    [Header("Input")]
    [SerializeField] InputManager inputManager;

    [Header("Networking")]
    [SerializeField] PhotonView photonView;

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
        
        if(!photonView.IsMine)
        {
            Destroy(vm_cam);
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;
        }
    }

    void Update()
    {
        if (!photonView.IsMine) return;

        Steer = inputManager.Turn;
        Throttle = inputManager.Move;

        foreach (var wheel in wheels)
        {
            wheel.SteerAngle = Steer * maxSteer;
            wheel.Torque = Throttle * motorTorque;
        }
    }
}
