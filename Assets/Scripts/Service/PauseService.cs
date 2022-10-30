using UnityEngine;

public class PauseService
{
    private bool _isPaused = false;
    private float _prevTimeScale = 1f;
    public void SetPause()
    {
        if (!_isPaused)
        {
            _isPaused = true;
            _prevTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
    }
    public void Resume()
    {
        if (_isPaused)
        {
            _isPaused = false;
            Time.timeScale = _prevTimeScale;
        }
    }
}
