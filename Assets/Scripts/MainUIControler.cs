using System.Threading.Tasks;
using UnityEngine;

public class MainUIContoroler : MonoBehaviour
{

    [SerializeField] private GameObject _mainMenuUI;
    [SerializeField] private GameObject _settingsMenuUI;
    [SerializeField] private GameObject _pauseMenuUI;
    [SerializeField] private GameObject _createGameUI;
    [SerializeField] private GameObject _gameplayUI;
    [SerializeField] private GameObject _loseMenuUI;

    public void StartGame()
    {
        _mainMenuUI.SetActive(false);
    }

    public void OpenSettings()
    {
        _settingsMenuUI.SetActive(true);  
    }

    public void CreateGameUI()
    {
        _createGameUI.SetActive(true);
    }

    public void PauseGame()
    {
        _pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Exit()
    {
        Application.Quit();
    }
}
