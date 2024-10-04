using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishingRod : MonoBehaviour
{
    public Transform rod;           // The fishing rod's transform
    public float maxPullbackAngle = -45f;  // Maximum pullback angle
    public float pullbackSpeed = 2f;  // Speed of pulling back
    public float resetSpeed = 5f;     // Speed of resetting to default

    private float holdTime = 0f;      // How long the button is held
    private bool isCasting = false;   // Whether the rod is casting (released)
    private float startRotation;      // Starting rotation of the rod

    void Start()
    {
        // Store the starting rotation of the rod
        startRotation = rod.localEulerAngles.z;
    }

    void Update()
    {
        // If left mouse button is held, increase hold time
        if (Input.GetMouseButton(0))
        {
            holdTime += Time.deltaTime;
            isCasting = false;

            // Calculate the current rotation based on the hold time
            float targetAngle = Mathf.Lerp(startRotation, maxPullbackAngle, holdTime * pullbackSpeed);

            // Apply the new rotation to the rod
            rod.localEulerAngles = new Vector3(0, 0, targetAngle);
        }
        else if (Input.GetMouseButtonUp(0)) // If the left mouse button is released
        {
            isCasting = true;
        }

        // When casting, reset the rod back to the default position
        if (isCasting)
        {
            // Smoothly rotate the rod back to the starting position
            float currentZ = rod.localEulerAngles.z;
            float resetAngle = Mathf.LerpAngle(currentZ, startRotation, Time.deltaTime * resetSpeed);
            rod.localEulerAngles = new Vector3(0, 0, resetAngle);

            // If the rod is close to its starting position, stop the cast
            if (Mathf.Abs(currentZ - startRotation) < 0.1f)
            {
                holdTime = 0;
                isCasting = false;
            }
        }
    }
}