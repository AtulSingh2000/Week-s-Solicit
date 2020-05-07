using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float SpeedH = 10f;
    public float SpeedV = 10f;

    private float yaw = 0f;
    private float pitch = 0f;
    private float minPitch = -30f;
    private float maxPitch = 60f;
    private float minYaw = -60f;
    private float maxYaw = 60f;



    void Update()
    {
        CameraRotate();
    }

    void CameraRotate()
    {
        yaw += Input.GetAxis("Mouse X") * SpeedH;
        pitch -= Input.GetAxis("Mouse Y") * SpeedV;
        pitch = Mathf.Clamp(pitch, minPitch, maxPitch);
        yaw = Mathf.Clamp(yaw, minYaw, maxYaw);
        transform.eulerAngles = new Vector3(pitch, yaw, 0f);

    }

  
}
