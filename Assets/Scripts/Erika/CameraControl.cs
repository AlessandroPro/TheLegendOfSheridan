using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float cameraSensitivity = 1.0f;
    public float distance = 5.0f;
    public Vector2 pitchMinMax = new Vector2(-20, 80);
    public Transform target;
    public float rotationSmoothing = 0.125f;

    private Vector3 rotationSmoothVelocity = Vector3.zero;
    private Vector3 currentRotation;

    [SerializeField] private float cameraYaw;
    [SerializeField] private float cameraPitch;


    void LateUpdate()
    {
        PlayerCameraControl();
    }

    void PlayerCameraControl()
    {
        cameraYaw += Input.GetAxis("Mouse X") * cameraSensitivity * Time.deltaTime;
        cameraPitch -= Input.GetAxis("Mouse Y") * cameraSensitivity * Time.deltaTime;
        cameraPitch = Mathf.Clamp(cameraPitch, pitchMinMax.x, pitchMinMax.y);
        Vector3 desiredRotation = new Vector3(cameraPitch, cameraYaw);

        currentRotation = Vector3.SmoothDamp(
            currentRotation,
            desiredRotation,
            ref rotationSmoothVelocity,
            rotationSmoothing);

        transform.eulerAngles = currentRotation;
        Vector3 desiredPosition = target.position - transform.forward * distance;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 0.5f);
    }
}
