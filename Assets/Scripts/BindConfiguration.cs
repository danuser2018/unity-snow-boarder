using Zenject;

public class BindConfiguration : MonoInstaller
{
    public override void InstallBindings()
    {
        Container.Bind<PlayerMovementCommand>().WithId("left").To<PlayerLeftMovementCommand>().AsSingle();
        Container.Bind<PlayerMovementCommand>().WithId("right").To<PlayerRightMovementCommand>().AsSingle();
        Container.Bind<PlayerMovementCommand>().WithId("default").To<PlayerDefaultMovementCommand>().AsSingle();
        Container.Bind<PlayerInputService>().To<PlayerInputServiceImpl>().AsSingle();
        Container.Bind<InputHandler>().To<InputHandlerAdapter>().AsSingle();
        Container.Bind<PlayerHandler>().To<PlayerHandlerAdapter>().AsSingle();
    }
}