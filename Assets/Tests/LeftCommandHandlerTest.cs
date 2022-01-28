using UnityEngine;
using Zenject;
using NUnit.Framework;

[TestFixture]
public class LeftCommandHandlerTest : ZenjectUnitTestFixture
{
    [SetUp]
    public void CommonInstall()
    {
        Container.BindInstance(1).WhenInjectedInto<LeftCommandHandler>();
        Container.Bind<LeftCommandHandler>().AsSingle();
    }

    [Test]
    public void WhenCallExecuteAddTorqueAmount()
    {
        // Given
        GameObject game = new GameObject();
        Rigidbody2D rb2d = game.AddComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rb2d.bodyType = RigidbodyType2D.Dynamic;
        rb2d.mass = 1f;
        rb2d.angularDrag = 0.05f;

        float initialAngularVelocity = rb2d.angularVelocity;
        float torqueAmount = 500f;
        float deltaTime = 1f;

        var handler = Container.Resolve<LeftCommandHandler>();

        // When
        handler.Execute(game, torqueAmount, deltaTime);
        float newAngularVelocity = rb2d.angularVelocity;

        Debug.Log(initialAngularVelocity);
        Debug.Log(newAngularVelocity);

        // Then
        Assert.That(newAngularVelocity > initialAngularVelocity);
    }
}