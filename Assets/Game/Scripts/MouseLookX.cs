using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLookX : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        CalculateMouseLook();
    }

    private void CalculateMouseLook()
    {
        float horizontalInput = Input.GetAxis("Mouse X");

        Vector3 newRotation = transform.localEulerAngles;
        newRotation.y += horizontalInput;
        transform.localEulerAngles = newRotation;

    }
}
