using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Puzzle;
using UnityEngine;
using UnityEngine.TestTools;

public class BasicCircuitNodeTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void BasicCircuitNodeInTrueValueTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        CircuitWireImpl circuitWire = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWire.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWire);
        circuitWire.SetValue(true);

        //get value
        //assert
        Assert.IsTrue(circuitNode.GetValue());
    }

    [Test]
    public void BasicCircuitNodeInFalseValueTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        CircuitWireImpl circuitWire = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWire.SetCurrentNode(circuitNode);
        circuitWire.SetValue(false);
        circuitNode.AddWire(circuitWire);

        //get value
        //assert
        Assert.IsFalse(circuitNode.GetValue());

    }

    [Test]
    public void BasicCircuitWireOutputTrueTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        CircuitWire circuitWireIn = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn.SetCurrentNode(circuitNode);
        circuitWireIn.SetValue(true);
        circuitNode.AddWire(circuitWireIn);

        CircuitWire circuitWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireOut.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireOut);

        //get value
        //assert
        Assert.IsTrue(circuitWireOut.GetValue());

    }

    [Test]
    public void BasicCircuitWireOutptFalseTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        CircuitWire circuitWireIn = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn.SetCurrentNode(circuitNode);
        circuitWireIn.SetValue(false);
        circuitNode.AddWire(circuitWireIn);

        CircuitWire circuitWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireOut.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireOut);

        //get value
        //assert
        Assert.IsFalse(circuitWireOut.GetValue());

    }


    [Test]
    public void BasicCircuitWireAllOutputFalseTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        CircuitWire circuitWireIn = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireIn.SetCurrentNode(circuitNode);
        circuitWireIn.SetValue(false);
        circuitNode.AddWire(circuitWireIn);

        CircuitWire circuitWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireOut.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireOut);

        //get value
        //assert
        Assert.IsFalse(circuitNode.GetValue());

    }

    [Test]
    public void BasicCircuitConnectedWireInputValueTrueTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        AbstractCircuitNode circuitNode0 = new BasicCircuitNode();
        CircuitWire connectedWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        connectedWireOut.SetCurrentNode(circuitNode0);
        CircuitWire circuitWireIn0 = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn0.SetCurrentNode(circuitNode0);
        circuitNode0.AddWire(circuitWireIn0);
        circuitNode0.AddWire(connectedWireOut);
        circuitWireIn0.SetValue(true);



        CircuitWire circuitWireIn = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn.SetConnectedWire(connectedWireOut);
        circuitWireIn.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireIn);

        CircuitWire circuitWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireOut.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireOut);

        //get value
        //assert
        Assert.IsTrue(circuitNode.GetValue());
        Assert.IsTrue(circuitWireIn.GetValue());
        Assert.IsTrue(circuitWireOut.GetValue());

    }


    [Test]
    public void BasicCircuitConnectedWireInputValueFalseTest()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode circuitNode = new BasicCircuitNode();

        //Add wire
        Renderer renderer = new Renderer();
        AbstractCircuitNode circuitNode0 = new BasicCircuitNode();
        CircuitWire connectedWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        connectedWireOut.SetCurrentNode(circuitNode0);
        CircuitWire circuitWireIn0 = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn0.SetCurrentNode(circuitNode0);
        //set value
        circuitWireIn0.SetValue(false);


        CircuitWire circuitWireIn = new CircuitWireImpl(Position.left, Direction.In, renderer, Color.red);
        circuitWireIn.SetConnectedWire(connectedWireOut);
        circuitWireIn.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireIn);

        CircuitWire circuitWireOut = new CircuitWireImpl(Position.left, Direction.Out, renderer, Color.red);
        circuitWireOut.SetCurrentNode(circuitNode);
        circuitNode.AddWire(circuitWireOut);

        //get value
        //assert
        Assert.IsFalse(circuitNode.GetValue());
        Assert.IsFalse(circuitWireIn.GetValue());
        Assert.IsFalse(circuitWireOut.GetValue());

    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator LogicGateTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
