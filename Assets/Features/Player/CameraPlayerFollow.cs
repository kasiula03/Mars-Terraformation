using System;
using UnityEngine;

public class CameraPlayerFollow : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Camera _camera;
    [SerializeField] private float _cameraRotationOffset;
    
    [SerializeField] private Vector3 _cameraPositionOffset;
    

    private float _cameraSpeed = 2f;

    public void Update()
    {
        var targetPosition = _target.transform.position + _target.transform.up * _cameraPositionOffset.y + _target.transform.forward * _cameraPositionOffset.x;

        float distance = Vector3.Distance(_camera.transform.position.normalized, targetPosition.normalized);

        if (Math.Abs(distance) > 0.01f)
        {
            _camera.transform.position = Vector3.Lerp(_camera.transform.position, targetPosition,
                _cameraSpeed * Time.deltaTime);
        }

        Vector3 newForward = _target.forward - (_target.up * _cameraRotationOffset);
     
        Quaternion targetRotation = Quaternion.LookRotation(newForward, _target.up);
        
        _camera.transform.rotation =  Quaternion.Lerp(_camera.transform.rotation,
            targetRotation,
             _cameraSpeed * Time.deltaTime);
    }
}