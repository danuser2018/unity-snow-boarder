using Zenject;

public class SnowBoarderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<LeftCommandHandler>().AsSingle();
        Container.Bind<RightCommandHandler>().AsSingle();
        Container.Bind<InputManager>().AsSingle();
    }
}