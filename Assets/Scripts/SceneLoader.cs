using UnityEngine.SceneManagement;

public class SceneLoader
{
    public static int PreloadSceneIndex = 0;
    public static int MainMenuSceneIndex = 1;
    public static int FirstLevelIndex = 2;
    public static int LastLevelIndex = 3;

    public void LoadSandLevel()
    {
        LoadScene(FirstLevelIndex);
    }

    public void LoadCityLevel()
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

    public void LoadScene(int index)
    {
        SceneManager.LoadScene(index);
    }
}
