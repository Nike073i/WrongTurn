using UnityEngine;
using Zenject;

public class GameManager : MonoBehaviour
{
    private SceneLoader _sceneLoader;

    public float ElapsedTime { get; private set; }
    public bool Running { get; private set; } = false;
    public bool Paused { get; private set; } = false;
    public bool Finished { get; private set; } = false;

    [Inject]
    private void Construct(SceneLoader sceneLoader)
    {
        _sceneLoader = sceneLoader;
    }

    private void Start()
    {
        Cursor.visible = false;
    }

    public void StartGame()
    {
        ElapsedTime = 0;
        Running = true;
        Finished = false;
    }

    public void FinishGame()
    {
        Running = false;
        Finished = true;
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private void Update()
    {
        if (Running && !Paused)
        {
            ElapsedTime += Time.deltaTime;
        }
    }

    public void PauseGame()
    {
        Paused = true;
    }

    public void ContinueGame()
    {
        Paused = false;
    }

    public void MainMenu()
    {
        _sceneLoader.LoadMainMenu();
    }

}
