using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private Transform _playerStartPoint;

    [SerializeField]
    private GameObject _finishPrefab;
    [SerializeField]
    private Transform _finishPoint;

    [SerializeField]
    private GameObject _pauseMenuUiPrefab;
    [SerializeField]
    private GameObject _startMenuUiPrefab;
    [SerializeField]
    private GameObject _finishMenuUiPrefab;
    [SerializeField]
    private GameObject _timeBarUiPrefab;

    public override void InstallBindings()
    {
        BindPauseService();
        BindRaceManager();
        InstantiatePlayer();
        BindFinishPoint();
        BindUiComponents();
    }

    private void InstantiatePlayer()
    {
        Container.InstantiatePrefab(_playerPrefab, _playerStartPoint);
    }

    private void BindUiComponents()
    {
        BindPauseMenuUi();
        BindStartMenuUi();
        BindFinishMenuUi();
        BindTimerBarUi();
    }

    private void BindPauseMenuUi()
    {
        var pauseMenu = Container.InstantiatePrefabForComponent<PauseMenu>(_pauseMenuUiPrefab);
        Container.Bind(typeof(PauseMenu))
            .FromInstance(pauseMenu)
            .AsSingle();
    }

    private void BindStartMenuUi()
    {
        var startMenu = Container.InstantiatePrefabForComponent<StartMenu>(_startMenuUiPrefab);
        Container.Bind(typeof(StartMenu))
            .FromInstance(startMenu)
            .AsSingle();
    }

    private void BindFinishMenuUi()
    {
        var finishMenu = Container.InstantiatePrefabForComponent<FinishMenu>(_finishMenuUiPrefab);
        Container.Bind(typeof(FinishMenu))
            .FromInstance(finishMenu)
            .AsSingle();
    }

    private void BindTimerBarUi()
    {
        var timerBar = Container.InstantiatePrefabForComponent<TimerBar>(_timeBarUiPrefab);
        Container.Bind(typeof(TimerBar))
            .FromInstance(timerBar)
            .AsSingle();
    }

    private void BindFinishPoint()
    {
        var finishZone = Container.InstantiatePrefabForComponent<FinishZone>(_finishPrefab, _finishPoint);
        Container.Bind(typeof(FinishZone))
            .FromInstance(finishZone)
            .AsSingle();
    }

    private void BindPauseService()
    {
        Container.Bind(typeof(PauseService))
            .AsSingle();
    }

    private void BindRaceManager()
    {
        Container.BindInterfacesAndSelfTo(typeof(RaceManager))
            .AsSingle();
    }
}