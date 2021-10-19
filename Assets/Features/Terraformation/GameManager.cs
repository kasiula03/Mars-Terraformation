using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TerraformationStats _terraformationStats;
    [SerializeField] private Canvas _finishedCanvas;
    [SerializeField] private Button _exitButton;

    private void Start()
    {
        _terraformationStats.OnGameFinished += GameFinish;
        _exitButton.onClick.AddListener(ExitGame);
        _finishedCanvas.gameObject.SetActive(false);
    }
    
    private void GameFinish()
    {
        _finishedCanvas.gameObject.SetActive(true);
    }
    
    private void ExitGame()
    {
        Application.Quit();
    }
}