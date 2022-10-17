using UnityEngine;

public class PreloadSceneManager : MonoBehaviour
{
    public SceneLoader GameSceneLoader;
    private void Start()
    {
        Cursor.visible = false;
        Invoke("LoadMainMenu", 3f);
    }

    private void LoadMainMenu()
    {
        GameSceneLoader.LoadMainMenu();
    }
}
