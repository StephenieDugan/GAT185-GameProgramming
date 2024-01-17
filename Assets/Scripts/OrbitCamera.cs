using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour
{
    [SerializeField] Transform target = null;
    [SerializeField][Range(20,90)] float defaultPitch = 40;
    [SerializeField][Range(20,90)] float defaultyaw = 0;
    [SerializeField][Range(2,8)] float distance = 5;
    [SerializeField][Range(0.1f,5.0f)] float sensitivity = 1;


    float yaw = 0;
    float pitch = 0;

    Quaternion qyaw;
    Quaternion qpitch;
    Quaternion qrotation;
    private void Start()
    {
        pitch = defaultPitch;
        yaw = defaultyaw;
    }

    void Update()
    {
        if(GameManager.Instance.state == GameManager.State.TITLE)
        {
            return;
        }
        yaw += Input.GetAxis("Mouse X") * sensitivity;
        pitch += -Input.GetAxis("Mouse Y") * sensitivity;
        pitch = Mathf.Clamp(pitch, -50, 50);


        qpitch = Quaternion.AngleAxis(pitch,Vector3.right);
        qyaw = Quaternion.AngleAxis(yaw,Vector3.up);
        qrotation = qyaw * qpitch;

        transform.position = target.position + (qrotation * Vector3.back * distance);
        transform.rotation = qrotation;
    }
}
