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
    private GameObject _locationUiPrefab;

    public override void InstallBindings()
    {
        InstantiatePlayer();
        BindFinishPoint();
        InstantiateUi();
    }

    private void InstantiatePlayer()
    {
        Container.InstantiatePrefab(_playerPrefab, _playerStartPoint);
    }

    private void InstantiateUi()
    {
        Container.InstantiatePrefab(_locationUiPrefab);
    }

    private void BindFinishPoint()
    {
        var finishZone = Container.InstantiatePrefabForComponent<FinishZone>(_finishPrefab, _finishPoint);
        Container.Bind(typeof(FinishZone))
            .FromInstance(finishZone)
            .AsSingle();
    }
}