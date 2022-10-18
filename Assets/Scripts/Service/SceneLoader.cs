using UnityEngine.SceneManagement;

public enum Scene
{
    Preload,
    MainMenu,
    SandLevel,
    CityLevel
}

public class SceneLoader
{
    public void LoadScene(Scene scene)
    {
        SceneManager.LoadScene((int)scene);
    }
}
