using Zenject;
using NUnit.Framework;

[TestFixture]
public class PlayerInputServiceTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<PlayerMovementCommand>().WithId("left").To<MockLeftCommand>().AsSingle();
        Container.Bind<PlayerMovementCommand>().WithId("right").To<MockRightCommand>().AsSingle();
        Container.Bind<PlayerMovementCommand>().WithId("default").To<MockDefaultCommand>().AsSingle();
        Container.Bind<InputHandler>().To<MockInputHandler>().AsSingle();
        Container.Bind<PlayerInputServiceImpl>().AsSingle();
    }

    [Test]
    public void TestReturnLeftCommand()
    {
        PlayerInputServiceImpl service = Container.Resolve<PlayerInputServiceImpl>();
        MockInputHandler inputHandler = (MockInputHandler) Container.Resolve<InputHandler>();
        inputHandler.left = true;

        var command = service.GetMovementCommand();

        Assert.That(command is MockLeftCommand);
    }

    [Test]
    public void TestReturnRightCommand()
    {
        PlayerInputServiceImpl service = Container.Resolve<PlayerInputServiceImpl>();
        MockInputHandler inputHandler = (MockInputHandler) Container.Resolve<InputHandler>();
        inputHandler.right = true;

        var command = service.GetMovementCommand();

        Assert.That(command is MockRightCommand);
    }

    [Test]
    public void TestReturnDefaultCommand()
    {
        PlayerInputServiceImpl service = Container.Resolve<PlayerInputServiceImpl>();
        MockInputHandler inputHandler = (MockInputHandler) Container.Resolve<InputHandler>();

        var command = service.GetMovementCommand();

        Assert.That(command is MockDefaultCommand);
    }

}

public class MockLeftCommand : PlayerMovementCommand
{
    public void Move(float torqueAmount)
    {
    }
}

public class MockRightCommand : PlayerMovementCommand
{
    public void Move(float torqueAmount)
    {
    }
}

public class MockDefaultCommand : PlayerMovementCommand
{
    public void Move(float torqueAmount)
    {
    }
}

public class MockInputHandler : InputHandler
{

    public bool left = false;
    public bool right = false;

    public bool IsKeyLeftPressed()
    {
        return left;
    }
    public bool IsKeyRightPressed()
    {
        return right;
    }
}