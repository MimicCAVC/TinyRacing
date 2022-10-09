using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TinyRacingInput;

public class DriftEnable : MonoBehaviour
{
    WheelFrictionCurve wheelFrictionCurve;

    WheelCollider[] wheelColliders;

    [SerializeField] InputManager inputManager;

    [SerializeField] ParticleSystem[] tyreSmokes;

    float sidwaysSlip;
    float forwardsSlip;

    void Start()
    {
        wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    void Update()
    {
        DriftConfig();
        HandleDriftSmoke();
    }

    void DriftConfig()
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

    void HandleDriftSmoke()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].GetGroundHit(out WheelHit wheelData);
            sidwaysSlip = wheelData.sidewaysSlip;
            forwardsSlip = wheelData.forwardSlip;

            if (sidwaysSlip >= 1)
            {
                startSmoke();
            }
            else
            {
                stopSmoke();
            }

            if (forwardsSlip >= 0.5f)
            {
                startSmoke();
            }
            else
            {
                stopSmoke();
            }
        }
    }

    void startSmoke()
    {
        for (int i = 0; i < tyreSmokes.Length; i++)
        {
            tyreSmokes[i].Play();
        }
    }

    void stopSmoke()
    {
        for (int i = 0; i < tyreSmokes.Length; i++)
        {
            tyreSmokes[i].Stop();
        }
    }
}
