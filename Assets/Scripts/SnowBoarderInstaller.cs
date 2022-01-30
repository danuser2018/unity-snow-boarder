using Zenject;

public class SnowBoarderInstaller : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<Command>().WithId("left").To<LeftCommand>().AsSingle();
        Container.Bind<Command>().WithId("right").To<RightCommand>().AsSingle();
        Container.Bind<Command>().WithId("default").To<DefaultCommand>().AsSingle();
        Container.Bind<InputHandler>().AsSingle();
    }
}