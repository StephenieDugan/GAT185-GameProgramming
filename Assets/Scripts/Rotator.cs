using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] [Range(-360, 360)] float rate;
   
    void Update()
    {
        transform.rotation *= Quaternion.AngleAxis(rate * Time.deltaTime, Vector3.up);
    }
}
