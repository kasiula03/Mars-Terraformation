using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private GameObject _target;
    [SerializeField] private Camera _camera;

    public float XSpeed = 1.5f;
    private float _sensivity = 17f;

    private void FixedUpdate()
    {
        if (Input.GetMouseButton(1))
        {
            transform.RotateAround(_target.transform.position, transform.up, -Input.GetAxis("Mouse X") * XSpeed);
            transform.RotateAround(_target.transform.position, transform.right, -Input.GetAxis("Mouse Y") * XSpeed);
        }

        if (Input.GetMouseButton(2))
        {
            Vector3 newTransform = transform.position;
            newTransform += transform.right * -Input.GetAxis("Mouse X");
            newTransform += transform.up * -Input.GetAxis("Mouse Y");
            transform.position = newTransform;
        }

        /* Vector3 desiredPosition = _target.transform.position + offset;
         Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, 0.125f);
         transform.position = smoothedPosition;
         transform.LookAt(_target.transform);*/

        float oSize = _camera.orthographicSize;
        oSize += Input.GetAxis("Mouse ScrollWheel") * -_sensivity;
        oSize = Mathf.Clamp(oSize, 1f, 100);
        _camera.orthographicSize = oSize;
    }
}
