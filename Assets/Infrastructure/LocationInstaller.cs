using UnityEngine;
using Zenject;

public class LocationInstaller : MonoInstaller
{
    [SerializeField]
    private GameObject _playerPrefab;

    [SerializeField]
    private Transform _playerStartPoint;

    public override void InstallBindings()
    {
        BindPlayer();

    }

    private void BindPlayer()
    {
        var playerController = Container.InstantiatePrefabForComponent<PlayerController>(_playerPrefab, _playerStartPoint);
        Container.Bind(typeof(PlayerController))
            .FromInstance(playerController)
            .AsSingle();
    }
}