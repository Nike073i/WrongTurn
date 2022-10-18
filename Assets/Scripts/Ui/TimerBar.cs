using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class TimerBar : MonoBehaviour
{
    [SerializeField]
    private GameObject _timeBarUi;

    [SerializeField]
    private Text _timeText;

    private readonly string _timeFormat = "F2";

    private GameManager _gameManager;

    [Inject]
    private void Construct(GameManager gameManager)
    {
        _gameManager = gameManager;
        _timeBarUi.SetActive(false);
        _gameManager.OnGameStateUpdated += OnGameStateUpdated;
    }

    private void OnGameStateUpdated(GameState prevState, GameState newState)
    {
        if (newState == GameState.Running)
            _timeBarUi.SetActive(true);
        else
            _timeBarUi.SetActive(false);
    }

    private void OnDestroy()
    {
        _gameManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    private void Update()
    {
        _timeText.text = _gameManager.ElapsedTime.ToString(_timeFormat);
    }
}
