using UnityEngine;
using Zenject;

public class SandLevelManager : MonoBehaviour
{
    private readonly string messageCont = "����������";
    private readonly string messageMenu = "� ����";
    private readonly string messageNext = "������� � ���������� ������";
    private readonly string messageBegin = "������";

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
        switch (_gameManager.CurrentState)
        {
            case (GameState.Pregame):
                {
                    StartMenuRender();
                    break;
                }
            case (GameState.Running):
                {
                    GameProcessMenuRender();
                    break;
                }
            case (GameState.Paused):
                {
                    PauseMenuRender();
                    break;
                }
            case (GameState.Finished):
                {
                    FinishMenuRender();
                    break;
                }
        }
    }

    private void StartMenuRender()
    {
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

        if (GUI.Button(button, messageBegin) || Input.GetKeyDown(KeyCode.Return))
        {
            _gameManager.StartGame();
        }
    }

    private void FinishMenuRender()
    {
        ;
        int time = (int)_gameManager.ElapsedTime;
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "�������� �����:");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
        if (GUI.Button(button, messageNext) || Input.GetKeyDown(KeyCode.Return))
        {
            //GameManager.GameSceneLoader.LoadLastLevel();
        }
    }

    private void GameProcessMenuRender()
    {
        int time = (int)_gameManager.ElapsedTime;
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "���� �����");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
    }

    private void PauseMenuRender()
    {

        Rect buttonCont = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        Rect buttonMenu = new Rect(Screen.width / 2 - 120, (Screen.height / 2) + buttonHeight + buttonMargin, 240, 30);

        if (GUI.Button(buttonCont, messageCont))
        {
            _gameManager.ResumeGame();
            return;
        }
        if (GUI.Button(buttonMenu, messageMenu))
        {
            _gameManager.MainMenu();
            return;
        }
    }
}
