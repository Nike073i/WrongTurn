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

    private RaceManager _raceManager;

    [Inject]
    private void Construct(RaceManager raceManager)
    {
        _raceManager = raceManager;
        _timeBarUi.SetActive(false);
        _raceManager.OnGameStateUpdated += OnGameStateUpdated;
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
        _raceManager.OnGameStateUpdated -= OnGameStateUpdated;
    }

    private void Update()
    {
        _timeText.text = _raceManager.ElapsedTime.ToString(_timeFormat);
    }
}
