using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FrustumControl : MonoBehaviour
{
    public Camera myCamera;

    [Header("FOV Angles (positive, in degrees) ")]
    public float left = 45f;
    public float right = 45f;
    public float bottom = 45f;
    public float top = 45f;

    private float leftDist, rightDist, topDist, bottomDist;


    void LateUpdate()
    {
        SetFrustum(myCamera, left,right,bottom,top);
    }


    /// <summary>
    /// Sets the camera frustum based on given FOV angles (positive, in degrees).
    /// </summary>
    public void SetFrustum(Camera cam, float left, float right, float bottom, float top)
    {
        leftDist = -1f * MathF.Tan(left * Mathf.Deg2Rad);
        rightDist = 1f * MathF.Tan(right * Mathf.Deg2Rad);
        bottomDist = -1f * MathF.Tan(bottom * Mathf.Deg2Rad);
        topDist = 1f * MathF.Tan(top * Mathf.Deg2Rad);

        Matrix4x4 m = PerspectiveOffCenter(leftDist, rightDist, bottomDist, topDist, 1f, 1000f);
        cam.projectionMatrix = m;
    }


    /// <summary>
    /// returns a projection matrix built from plane distances.
    /// </summary>
    static Matrix4x4 PerspectiveOffCenter(float left, float right, float bottom, float top, float near, float far)
    {
        float x = 2.0F * near / (right - left);
        float y = 2.0F * near / (top - bottom);
        float a = (right + left) / (right - left);
        float b = (top + bottom) / (top - bottom);
        float c = -(far + near) / (far - near);
        float d = -(2.0F * far * near) / (far - near);
        float e = -1.0F;
        Matrix4x4 m = new Matrix4x4();
        m[0, 0] = x; m[0, 1] = 0; m[0, 2] = a; m[0, 3] = 0;
        m[1, 0] = 0; m[1, 1] = y; m[1, 2] = b; m[1, 3] = 0;
        m[2, 0] = 0; m[2, 1] = 0; m[2, 2] = c; m[2, 3] = d;
        m[3, 0] = 0; m[3, 1] = 0; m[3, 2] = e; m[3, 3] = 0;
        return m;
    }
    
}
