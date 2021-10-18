using UnityEngine;

public class BuildingActionController : MonoBehaviour
{
    private BuildingAction _buildingAction;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_buildingAction != null && _buildingAction.IsActionAvailable())
            {
                _buildingAction.Execute();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BuildingAction"))
        {
            _buildingAction = other.GetComponent<BuildingAction>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("BuildingAction"))
        {
            _buildingAction = null;
        }
    }
}