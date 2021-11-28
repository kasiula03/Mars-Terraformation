using UnityEngine;


public class CameraZoom : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    
    public float _sensivity = 17f;

    private void Update()
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        if (scroll != 0)
        {
            float oSize = _camera.orthographicSize;
            oSize += scroll * -_sensivity;
            oSize = Mathf.Clamp(oSize, 1f, 100);
            _camera.orthographicSize = oSize;
        }
    }
}