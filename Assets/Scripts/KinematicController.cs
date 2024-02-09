using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KinematicController : MonoBehaviour
{
    [SerializeField, Range(0,40)] float speed = 1;
    [SerializeField, Range(0,40)] float yaw = 1;
    [SerializeField, Range(0,40)] float pitch = 1;
    [SerializeField] float maxDistance = 5;

    // Update is called once per frame
    void Update()
    {
        

        Vector3 direction = Vector3.zero;


        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");

        Vector3 Force = direction  * speed * Time.deltaTime;
        transform.localPosition += Force;

        transform.localPosition = Vector3.ClampMagnitude(transform.localPosition, maxDistance);
        Quaternion qyaw = Quaternion.AngleAxis(direction.x * yaw, Vector3.up);
        Quaternion qpitch = Quaternion.AngleAxis(direction.y * pitch, Vector3.right);
        Quaternion rotation = qyaw * qpitch;

        transform.localRotation = Quaternion.Lerp(transform.rotation, rotation, speed);


    }
   
}
