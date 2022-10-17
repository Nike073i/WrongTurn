using Zenject;

public class PreloadInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        BindPreloadScript();
    }

    private void BindPreloadScript()
    {
        Container.InstantiateComponentOnNewGameObject<PreloadScript>();
    }
}