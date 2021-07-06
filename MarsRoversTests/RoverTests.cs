using System;
using System.Collections.Generic;
using MarsRover;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MarsRoverTests
{
    [TestClass]
    public class RoverTests
    {

        [TestMethod]
        public void ConstructorSetsDefaultPosition()
        {
            // want to verify the message in Receive message are equal to the messages that are passed in the other classes
            Rover rove = new Rover(20);
            Assert.AreEqual(rove.Position, 20);

        }

        [TestMethod]
        public void ConstructorSetsDefaultMode()
        {
            Rover rove = new Rover(0);
            Assert.AreEqual(rove.Mode, "NORMAL");
        }

        [TestMethod]
        public void ConstructorSetsDefaultGenaratorWatts()
        {

            Rover rove = new Rover(0);
            Assert.AreEqual(rove.GeneratorWatts, 110);
        }

        [TestMethod]
        public void RespondsCorrectlyToModeChangeCommand()
        {

            Rover rove = new Rover(0);            
            Command[] cmd = {new Command("MODE CHANGE", "LOW_POWER")};
            Message msg = new Message("Name", cmd);
            rove.ReceiveMessage(msg);
            Assert.AreEqual(rove.Mode, "LOW_POWER");

        }

        [TestMethod]
        public void DoesNotMoveInLower()
        {
            Rover rove = new Rover(20,"LOW_POWER",110);
            Command[] cmd = { new Command("MOVE", 30) };
            Message msg = new Message("Name", cmd);
            rove.ReceiveMessage(msg);
            
            Assert.AreEqual(rove.Position, 20);
        }

        [TestMethod]
        public void PositionChangesFromMoveCommand()
        {
            Command[] cmd = { new Command("MOVE", 20) };
            Message msg = new Message("Name", cmd);
            Rover rove = new Rover(40);
            rove.ReceiveMessage(msg);
            Assert.AreEqual(rove.Position, 40);

        }

    }
}