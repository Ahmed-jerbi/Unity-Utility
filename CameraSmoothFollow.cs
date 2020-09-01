/*
Camera Script for smooth following
*/
using UnityEngine;
using System.Collections;

public class CameraSmoothFollow : MonoBehaviour
{
    public bool shouldRotate = true;
    // The target we are following
    public Transform target;
    // offset between camera and target
    private Vector3 Offset;
    // change this value to get desired smoothness
    public float SmoothTime = 0.8f;
    private Vector3 velocity = Vector3.zero;
   
    void Start()
    {
        Offset = transform.position - target.position;
    }


    void LateUpdate()
    {

        Vector3 targetPosition = target.position + Offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, SmoothTime);

        // update rotation
        transform.LookAt(target);
    }

}
