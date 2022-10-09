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

    [SerializeField] TrailRenderer[] skidMarks;

    float sidwaysSlip;
    float forwardsSlip;

    void Start()
    {
        wheelColliders = GetComponentsInChildren<WheelCollider>();
    }

    void Update()
    {
        DriftConfig();
        HandleDriftEffects();
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

    void HandleDriftEffects()
    {
        for (int i = 0; i < wheelColliders.Length; i++)
        {
            wheelColliders[i].GetGroundHit(out WheelHit wheelData);
            sidwaysSlip = wheelData.sidewaysSlip;
            forwardsSlip = wheelData.forwardSlip;

            if (sidwaysSlip >= 0.8f)
            {
                startSmoke();
                startSkid();
            }
            else
            {
                stopSmoke();
                stopSkid();
            }

            if (forwardsSlip >= 0.5f)
            {
                startSmoke();
                startSkid();
            }
            else
            {
                stopSmoke();
                stopSkid();
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

    void startSkid()
    {
        for (int i = 0; i < skidMarks.Length; i++)
        {
            skidMarks[i].emitting = true;
        }
    }
    void stopSkid()
    {
        for (int i = 0; i < skidMarks.Length; i++)
        {
            skidMarks[i].emitting = false;
        }
    }
}
