using UnityEngine;

public class PauseService
{
    private bool _isPaused;
    private float _normalTimeScale;

    public PauseService()
    {
        _isPaused = false;
        _normalTimeScale = 1f;
    }

    public void SetPause()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = _normalTimeScale;
        }
    }
}
