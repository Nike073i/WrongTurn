using UnityEngine;

public class SandLevelManager : MonoBehaviour
{
    private readonly string messageCont = "Продолжить";
    private readonly string messageMenu = "В меню";
    private readonly string messageNext = "Перейти к следующему уровню";
    private readonly string messageBegin = "Начать";

    private readonly int buttonHeight = 30;
    private readonly int buttonMargin = 5;

    public GameManager GameManager;

    private void OnGUI()
    {
        if (GameManager.Finished)
        {
            FinishMenuRender();
            return;
        }
        if (!GameManager.Running)
        {
            StartMenuRender();
            return;
        }
        if (GameManager.Paused)
        {
            PauseMenuRender();
            return;
        }
        if (GameManager.Running)
        {
            GameProcessMenuRender();
            return;
        }
    }

    private void StartMenuRender()
    {
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);

        if (GUI.Button(button, messageBegin) || Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.StartGame();
        }
    }

    private void FinishMenuRender()
    {
        ;
        int time = (int)GameManager.ElapsedTime;
        Rect button = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Итоговое время:");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
        if (GUI.Button(button, messageNext) || Input.GetKeyDown(KeyCode.Return))
        {
            GameManager.GameSceneLoader.LoadLastLevel();
        }
    }

    private void GameProcessMenuRender()
    {
        int time = (int)GameManager.ElapsedTime;
        GUI.Box(new Rect(Screen.width / 2 - 65, Screen.height - 115, 130, 40), "Ваше время");
        GUI.Label(new Rect(Screen.width / 2 - 10, Screen.height - 100, 20, 30), time.ToString());
    }

    private void PauseMenuRender()
    {

        Rect buttonCont = new Rect(Screen.width / 2 - 120, Screen.height / 2, 240, 30);
        Rect buttonMenu = new Rect(Screen.width / 2 - 120, (Screen.height / 2) + buttonHeight + buttonMargin, 240, 30);

        if (GUI.Button(buttonCont, messageCont))
        {
            GameManager.ContinueGame();
            return;
        }
        if (GUI.Button(buttonMenu, messageMenu))
        {
            GameManager.MainMenu();
            return;
        }
    }
}
