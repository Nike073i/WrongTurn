using Assets.Scripts.Game;
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
            .AsSingle();
    }

    private void BindGameManager()
    {
        Container.Bind(typeof(GameManager))
            .AsSingle();
    }
}