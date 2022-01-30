using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using UnityEngine.TestTools;

public class MovementTest: InputTestFixture
{
    Keyboard keyboard;

    [OneTimeSetUp]
    public void SetUp() {
        SceneManager.LoadScene("SampleScene");
        keyboard = InputSystem.AddDevice<Keyboard>();
    }

    [UnityTest]
    public IEnumerator TestLeftPressed()
    {
        GameObject gameObject = GameObject.FindWithTag("Player");
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();

        Press(keyboard.leftArrowKey);

        yield return null;

        Assert.IsTrue(rigidbody2D.angularVelocity > 0);
    }

        [UnityTest]
    public IEnumerator TestRightPressed()
    {
        GameObject gameObject = GameObject.FindWithTag("Player");
        Rigidbody2D rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
        Command leftCommand = new LeftCommand();

        leftCommand.Execute(rigidbody2D, 1F);

        yield return null;

        Assert.IsTrue(rigidbody2D.angularVelocity > 0);
    }

}
