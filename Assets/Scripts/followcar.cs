using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followcar : MonoBehaviour
{
    public Transform car;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = car.position;
    }
}
