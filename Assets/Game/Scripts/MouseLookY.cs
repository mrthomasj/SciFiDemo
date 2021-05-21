using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookY : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CalculateMouseLook();
    }

    private void CalculateMouseLook()
    {
        float verticalInput = Input.GetAxis("Mouse Y");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.x -= verticalInput;
        transform.localEulerAngles = newRotation;

    }
}

