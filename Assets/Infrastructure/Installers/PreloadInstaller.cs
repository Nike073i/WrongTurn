using Zenject;

public class PreloadInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        InstantiatePreloadScene();
    }

    private void InstantiatePreloadScene()
    {
        Container.InstantiateComponentOnNewGameObject<PreloadScene>();
    }
}