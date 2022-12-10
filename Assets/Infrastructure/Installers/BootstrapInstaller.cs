using Assets.Scripts.Game;
using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    private readonly string _serverBaseUrl = "https://localhost:17256";

    public override void InstallBindings()
    {
        BindSceneLoader();
        BindGameManager();
        BindServerProxy();
        BindPlayerProfile();
    }

    private void BindSceneLoader()
    {
        Container.Bind(typeof(SceneLoader))
            .AsSingle();
    }

    private void BindPlayerProfile()
    {
        Container.Bind(typeof(PlayerProfile))
            .AsSingle();
    }

    private void BindServerProxy()
    {
        Container.Bind(typeof(IServerProxy))
            .To(typeof(ServerProxy))
            .FromInstance(new ServerProxy(_serverBaseUrl))
            .AsTransient();
    }

    private void BindGameManager()
    {
        Container.Bind(typeof(GameManager))
            .AsSingle();
    }
}