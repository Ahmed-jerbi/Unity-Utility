using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Calculates and applies vertical FOV to the camera where the script is attached, horizontal will be automatically determined from the aspect ratio (game view resolution or render texture)
/// </summary>
public class CAVE_FOV_Calculator : MonoBehaviour
{
    [Header("Inputs (Units don't matter, it's a ratio)")]
    [Tooltip("Height of the wall")]
    public float wallHeight = 3000f;

    [Tooltip("Distance from the eye to the wall")]
    public float eyeDistance = 2000f;

    private Camera cam;

    void Start()
    {
        // Get the Camera component
        cam = GetComponent<Camera>();

        if (cam == null)
        {
            Debug.LogError("No Camera component found on this GameObject!");
            return;
        }

        // Vertical FOV formula: 2 * arctan((height / 2) / distance)
        float halfAngle = Mathf.Atan((wallHeight / 2.0f) / eyeDistance);
        float verticalFOV = 2.0f * Mathf.Rad2Deg * halfAngle;

        // Apply FOV to the Camera
        cam.fieldOfView = verticalFOV;

        Debug.Log($"Calculated Vertical FOV: {verticalFOV}°");

        // Check Vertical
        float horizontalFOV = 2.0f * Mathf.Atan(Mathf.Tan(verticalFOV * Mathf.Deg2Rad / 2.0f) * cam.aspect) * Mathf.Rad2Deg;

        // Log the result
        Debug.Log($"Resulted Horizontal FOV: {horizontalFOV}° - based on aspect ratio: {cam.aspect} ");
    }


}



