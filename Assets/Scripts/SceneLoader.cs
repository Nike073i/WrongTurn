using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static int PreloadSceneIndex = 0;
    public static int MainMenuSceneIndex = 1;
    public static int FirstLevelIndex = 2;
    public static int LastLevelIndex = 3;

    public void LoadFirstLevel()
    {
        LoadScene(FirstLevelIndex);
    }

    public void LoadLastLevel()
    {
        LoadScene(LastLevelIndex);
    }

    public void LoadMainMenu()
    {
        LoadScene(MainMenuSceneIndex);
    }

    public void LoadPreloadScene()
    {
        LoadScene(PreloadSceneIndex);
    }

    private void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
