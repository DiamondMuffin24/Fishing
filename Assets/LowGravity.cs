using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowGravity : MonoBehaviour
{
    // Public variable for gravity multiplier
    public float gravityMultiplier = 0.2f;

    // Reference to the object's Rigidbody component
    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the object
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply custom gravity force
        Vector3 lowGravity = Physics.gravity * gravityMultiplier;
        rb.AddForce(lowGravity, ForceMode.Acceleration);
    }
}