using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using Puzzle;
using UnityEngine;
using UnityEngine.TestTools;

public class NodeCreatorTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void TestCreateBasicCircuitNode()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode node = NodeCreator.CreateCircuitNode(NodeType.basic);

        Assert.IsAssignableFrom<BasicCircuitNode>(node);
    }

    [Test]
    public void TestCreateAndGateCircuitNode()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode node = NodeCreator.CreateCircuitNode(NodeType.and);

        Assert.IsAssignableFrom<AndGateCircuitNode>(node);
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator NodeCreatorTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
