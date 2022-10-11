using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class Wheel : NetworkBehaviour
{
    [SerializeField] bool steer;
    [SerializeField] bool invertSteer;
    [SerializeField] bool power;

    public float SteerAngle { get; set; }
    public float Torque { get; set; }

    private WheelCollider wheelCollider;
    private Transform wheelTransform;

    // Start is called before the first frame update
    void Start()
    {
        wheelCollider = GetComponentInChildren<WheelCollider>();
        wheelTransform = GetComponentInChildren<MeshCollider>().GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        wheelCollider.GetWorldPose(out Vector3 pos, out Quaternion rot);
        wheelTransform.position = pos;
        wheelTransform.rotation = rot * Quaternion.Euler(0f, 0f, -90f);
    }

    void FixedUpdate()
    {
        if (!IsOwner) return;

        if (steer)
        {
            wheelCollider.steerAngle = SteerAngle * (invertSteer ? -1 : 1);
        }

        if (power)
        {
            wheelCollider.motorTorque = Torque;
        }
    }
}