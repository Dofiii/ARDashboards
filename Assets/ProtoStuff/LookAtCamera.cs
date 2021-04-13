using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    [SerializeField]
    private bool reverseLookAt = false;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if (!reverseLookAt)
        {
            transform.LookAt(mainCamera.transform);
        }
        else
        {
            LookAtBackwards(mainCamera.transform.position);
        }

        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }

    private void LookAtBackwards (Vector3 target)
    {
        Vector3 offset = transform.position - target;
        transform.LookAt(transform.position + offset);
    }
}
