/*
Camera Script for following a vehicule
*/

using UnityEngine;

public class CameraVehiculeController : MonoBehaviour {
    public Transform VehicleTransform;
    public float DistanceFromVehicle;
    public float HeightFromVehicle;
    public float RotationDamping;
    public float HeightDamping;

    void LateUpdate()
    {
        var angle = VehicleTransform.eulerAngles.y;
        var height = HeightFromVehicle + VehicleTransform.position.y;

        var cameraAngle = transform.eulerAngles.y;
        var cameraHeight = transform.position.y;

        cameraAngle = Mathf.LerpAngle(cameraAngle, angle, RotationDamping * Time.deltaTime);
        cameraHeight = Mathf.Lerp(cameraHeight, height, HeightDamping * Time.deltaTime);

        var currentRotation = Quaternion.Euler(0, cameraAngle, 0);
        transform.position = VehicleTransform.position;
        transform.position -= currentRotation * Vector3.forward * DistanceFromVehicle;

        var tmp = transform.position;
        tmp.y = cameraHeight;

        transform.position = tmp;
        transform.LookAt(VehicleTransform);
    }
}
