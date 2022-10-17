using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
        BindPauseService();
        BindGameManager();
    }

    private void BindSceneLoader()
    {
        Container.Bind(typeof(SceneLoader))
                .AsTransient();
    }

    private void BindGameManager()
    {
        var gameManager = Container.Bind(typeof(GameManager))
            .FromNewComponentOnNewGameObject()
            .AsSingle();
    }

    private void BindPauseService()
    {
        Container.Bind(typeof(PauseService))
            .AsTransient();
    }
}