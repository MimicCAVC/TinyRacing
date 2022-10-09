using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField] float motorTorque = 100f;
    [SerializeField] float maxSteer = 30f;

    [SerializeField] Transform centreOfMass;

    [SerializeField] float Steer { get; set; }
    [SerializeField] float Throttle { get; set; }

    Rigidbody carRB;

    private void Start()
    {
        carRB = GetComponent<Rigidbody>();
        carRB.centerOfMass = centreOfMass.localPosition;
    }

    void FixedUpdate()
    {

    }

    void Update()
    {

    }
}
