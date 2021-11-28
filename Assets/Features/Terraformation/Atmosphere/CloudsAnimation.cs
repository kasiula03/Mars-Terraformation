using System;
using UnityEngine;

public class CloudsAnimation : MonoBehaviour
{
    [SerializeField] private Transform _aroundTarget;

    private float timeCounter = 0;

    private void Update()
    {
        timeCounter += Time.deltaTime * 0.05f;

        //  float radius = Vector3.Distance(_aroundTarget.position, transform.position);
        float radius = 20;
        float x = _aroundTarget.position.x + radius * Mathf.Cos(timeCounter);

        float y = _aroundTarget.position.y + radius * Mathf.Sin(timeCounter);
        //float y = 0;
        float z = _aroundTarget.position.z + radius * Mathf.Sin(timeCounter);

        transform.position = new Vector3(x, y, z);

        transform.rotation = Quaternion.FromToRotation(_aroundTarget.up, transform.position);
    }
}