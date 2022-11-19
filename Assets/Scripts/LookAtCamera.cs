using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        var cameraDirection = (Camera.main.transform.position - transform.position).normalized;

        transform.LookAt(transform.position + cameraDirection * -1);
    }
}
