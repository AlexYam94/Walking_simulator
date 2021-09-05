using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Puzzle;

public class AndGateTests
{
    // A Test behaves as an ordinary method
    [Test]
    public void NoInWiresResultFalse()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();
        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        Assert.IsFalse(andGate.GetValue());
    }


    [Test]
    public void OneInFalseWiresResultFalse()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();

        AbstractCircuitNode powerSource = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire.SetCurrentNode(powerSource);
        powerSource.AddWire(connectedWire);

        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire1.SetConnectedWire(connectedWire);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        connectedWire.SetValue(false);

        Assert.IsFalse(andGate.GetValue());
    }

    [Test]
    public void OneInTrueWiresResultFalse()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();


        AbstractCircuitNode powerSource = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire.SetCurrentNode(powerSource);
        powerSource.AddWire(connectedWire);


        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire1.SetConnectedWire(connectedWire);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        connectedWire.SetValue(true);

        Assert.IsFalse(andGate.GetValue());
    }

    [Test]
    public void TwoInWiresBothFalseResultFalse()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();

        AbstractCircuitNode powerSource = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire.SetCurrentNode(powerSource);
        powerSource.AddWire(connectedWire);


        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire1.SetConnectedWire(connectedWire);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire2.SetConnectedWire(connectedWire);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        connectedWire.SetValue(true);

        Assert.IsFalse(andGate.GetValue());
    }

    [Test]
    public void TwoInWiresOneTrueOneFalseResultFalse()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();

        AbstractCircuitNode powerSource1 = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire.SetCurrentNode(powerSource1);
        powerSource1.AddWire(connectedWire);
        connectedWire.SetValue(false);
        
        AbstractCircuitNode powerSource2 = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire2 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire2.SetCurrentNode(powerSource2);
        powerSource2.AddWire(connectedWire2);


        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire1.SetConnectedWire(connectedWire);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire2.SetConnectedWire(connectedWire2);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        connectedWire.SetValue(true);

        Assert.IsFalse(andGate.GetValue());
    }

    [Test]
    public void TwoInWiresBothTrueResultTrue()
    {
        // Use the Assert class to test conditions
        AbstractCircuitNode andGate = NodeCreator.CreateCircuitNode(NodeType.and);
        Renderer renderer = new Renderer();

        AbstractCircuitNode powerSource1 = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire.SetCurrentNode(powerSource1);
        powerSource1.AddWire(connectedWire);

        AbstractCircuitNode powerSource2 = NodeCreator.CreateCircuitNode(NodeType.basic);
        CircuitWire connectedWire2 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        connectedWire2.SetCurrentNode(powerSource2);
        powerSource2.AddWire(connectedWire2);


        CircuitWire wire1 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire1.SetConnectedWire(connectedWire);
        CircuitWire wire2 = new CircuitWireImpl(Position.bottom, Direction.In, renderer, Color.red);
        wire2.SetConnectedWire(connectedWire2);
        CircuitWire wire3 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        CircuitWire wire4 = new CircuitWireImpl(Position.bottom, Direction.Out, renderer, Color.red);
        andGate.AddWire(wire1);
        andGate.AddWire(wire2);
        andGate.AddWire(wire3);
        andGate.AddWire(wire4);

        connectedWire.SetValue(true);
        connectedWire2.SetValue(true);

        Assert.IsTrue(andGate.GetValue());
    }

    // A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    // `yield return null;` to skip a frame.
    [UnityTest]
    public IEnumerator AndGateTestsWithEnumeratorPasses()
    {
        // Use the Assert class to test conditions.
        // Use yield to skip a frame.
        yield return null;
    }
}
