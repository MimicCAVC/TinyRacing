using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriftEnable : MonoBehaviour
{
   [SerializeField] WheelCollider wheelCol;
    WheelFrictionCurve wheelFrictionCurve;
    // Start is called before the first frame update
    void Start()
    {
        wheelCol.GetComponent<WheelCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            wheelFrictionCurve = wheelCol.sidewaysFriction;

            wheelFrictionCurve.extremumSlip = 1f;
            wheelFrictionCurve.extremumValue = 1f;
            wheelFrictionCurve.asymptoteSlip = 1f;
            wheelFrictionCurve.asymptoteValue = 1f;
            wheelFrictionCurve.stiffness = 1f;

            wheelCol.sidewaysFriction = wheelFrictionCurve;
        }
        else
        {
            wheelFrictionCurve.extremumSlip = 3f;
            wheelFrictionCurve.extremumValue = 3f;
            wheelFrictionCurve.asymptoteSlip = 3f;
            wheelFrictionCurve.asymptoteValue = 3f;
            wheelFrictionCurve.stiffness = 3f;

            wheelCol.sidewaysFriction = wheelFrictionCurve;
        }
    }
}
