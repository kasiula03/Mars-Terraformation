using Cysharp.Threading.Tasks;
using UnityEngine;

public class BuildingActionController : MonoBehaviour
{
    public bool BlockInput => _blockInput;
    
    private BuildingAction _buildingAction;
    private bool _blockInput;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !_blockInput)
        {
            if (_buildingAction != null && _buildingAction.IsActionAvailable())
            {
                _blockInput = _buildingAction.IsBlocking();
                _buildingAction.Execute(OnEndAction);
            }
        }
    }

    private void OnEndAction()
    {
        _blockInput = false;
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