using UnityEngine;

public class ComputerOpenAction : MonoBehaviour, BuildingAction
{
    [SerializeField] private RectTransform _computerPanel;
    
    public bool IsActionAvailable()
    {
        return true;
    }

    public void Execute()
    {
        _computerPanel.gameObject.SetActive(true);
    }
}