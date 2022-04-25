using UnityEngine;

public class LevelKeybordController : MonoBehaviour
{
    [Header("Set in Inspector")]
    public GameManager GameManager;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameManager.Running)
            {
                if (!GameManager.Paused)
                {
                    Cursor.visible = true;
                    GameManager.PauseGame();
                    return;
                }
                if (GameManager.Paused)
                {
                    Cursor.visible = false;
                    GameManager.ContinueGame();
                }
            }
        }
    }
}
