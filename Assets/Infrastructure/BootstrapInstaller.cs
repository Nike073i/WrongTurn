using Zenject;

public class BootstrapInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindSceneLoader();
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
}