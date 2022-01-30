using Zenject;
using NUnit.Framework;

[TestFixture]
public class PlayerMovementCommandsTest : ZenjectUnitTestFixture
{

    [SetUp]
    public void CommonInstall()
    {
        Container.Bind<PlayerHandler>().To<MockPlayerHandler>().AsSingle();
        Container.Bind<PlayerDefaultMovementCommand>().AsSingle();
        Container.Bind<PlayerLeftMovementCommand>().AsSingle();
        Container.Bind<PlayerRightMovementCommand>().AsSingle();
    }

    [Test]
    public void TestDefaultCommand()
    {
        var command = Container.Resolve<PlayerDefaultMovementCommand>();
        command.Move(1.0f);

        var playerHandler = (MockPlayerHandler) Container.Resolve<PlayerHandler>();

        Assert.That(playerHandler.timesInvoked == 0);
        Assert.That(playerHandler.torqueAmount == 0.0f);
    }
    
    [Test]
    public void TestLeftCommand()
    {
        var command = Container.Resolve<PlayerLeftMovementCommand>();
        command.Move(1.0f);

        var playerHandler = (MockPlayerHandler) Container.Resolve<PlayerHandler>();

        Assert.That(playerHandler.timesInvoked == 1);
        Assert.That(playerHandler.torqueAmount == 1.0f);
    }

    [Test]
    public void TestRightCommand()
    {
        var command = Container.Resolve<PlayerRightMovementCommand>();
        command.Move(1.0f);

        var playerHandler = (MockPlayerHandler) Container.Resolve<PlayerHandler>();

        Assert.That(playerHandler.timesInvoked == 1);
        Assert.That(playerHandler.torqueAmount == -1.0f);
    }
}

public class MockPlayerHandler : PlayerHandler
{
    public int timesInvoked = 0;
    public float torqueAmount = 0.0f;

    public void AddTorque(float torqueAmount) {
        this.timesInvoked++;
        this.torqueAmount = torqueAmount;
    }
}