using UnityEngine;
using Zenject;

public class CityLevelManager : MonoBehaviour
{
    private readonly string _messageContinue = "Продолжить";
    private readonly string _messageMenu = "В меню";
    private readonly string _messageRepeat = "Повторить";
    private readonly string _messageBegin = "Старт";

    private readonly int buttonHeight = 30;
    private readonly int buttonMargin = 5;

    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
    }

    private void OnGUI()
    {
        if (_gameManager.Finished)
        {
            FinishMenuRender();
            return;
        }
        if (!_gameManager.Running)
        {
            StartMenuRender();
            return;
        }
        if (_gameManager.Paused)
        {
            PauseMenuRender();
            return;
        }
        if (_gameManager.Running)
        {
            GameProcessMenuRender();
            return;
        }
    }

    private void StartMenuRender()
    {
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

        if (GUI.Button(button, _messageBegin) || Input.GetKeyDown(KeyCode.Return))
        {
            _gameManager.StartGame();
        }
    }

    private void FinishMenuRender()
    {

        int time = (int)_gameManager.ElapsedTime;
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Затраченное время:");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
        if (GUI.Button(button, _messageRepeat) || Input.GetKeyDown(KeyCode.Return))
        {
            //GameManager.GameSceneLoader.LoadLastLevel();
        }
    }

    private void GameProcessMenuRender()
    {
        int time = (int)_gameManager.ElapsedTime;
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Текущее время:");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
    }

    private void PauseMenuRender()
    {

        Rect buttonCont = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        Rect buttonMenu = new Rect(Screen.width / 2 - 120, (Screen.height / 2) + buttonHeight + buttonMargin, 240, 30);

        if (GUI.Button(buttonCont, _messageContinue))
        {
            _gameManager.ContinueGame();
            return;
        }
        if (GUI.Button(buttonMenu, _messageMenu))
        {
            _gameManager.MainMenu();
            return;
        }
    }
}
