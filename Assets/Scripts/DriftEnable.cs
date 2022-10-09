using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyRacingInput;

public class DriftEnable : MonoBehaviour
{
    WheelFrictionCurve wheelFrictionCurve;

    WheelCollider[] wheelColliders;

    [SerializeField] InputManager inputManager;

    void Start()
    {
        wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    void Update()
    {
        foreach (var wheel in wheelColliders)
        {
            if (inputManager.Drift == true)
            {
                wheelFrictionCurve = wheel.sidewaysFriction;

                wheelFrictionCurve.extremumSlip = 1f;
                wheelFrictionCurve.extremumValue = 1f;
                wheelFrictionCurve.asymptoteSlip = 1f;
                wheelFrictionCurve.asymptoteValue = 1f;
                wheelFrictionCurve.stiffness = 1f;

                wheel.sidewaysFriction = wheelFrictionCurve;
            }
            else
            {
                wheelFrictionCurve.extremumSlip = 3f;
                wheelFrictionCurve.extremumValue = 3f;
                wheelFrictionCurve.asymptoteSlip = 3f;
                wheelFrictionCurve.asymptoteValue = 3f;
                wheelFrictionCurve.stiffness = 3f;

                wheel.sidewaysFriction = wheelFrictionCurve;
            }
        }
    }
}
