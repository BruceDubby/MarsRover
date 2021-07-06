using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MarsRover;

namespace MarsRoverTests
{
    [TestClass]
    public class MessageTests

    {
        // Message message1;
        // string testName;
        //[TestInitialize]
        //public void CreateClassInstances()
        // {
        //     message1 = new Message(testName);
        //     testName = "Message 1";
        // }

        Command[] commands = { new Command("foo", 0), new Command("bar", 20) };

        [TestMethod]
        public void ArgumentNullExceptionThrownIfNameNotPassedToConstructor()
        {
            try
            {
               new Message("", commands);
            }

            catch (ArgumentNullException ex)
            {
            Assert.AreEqual("Name is required", ex.Message);
            }
        }

        [TestMethod]
        public void ConstructorSetsName()
        {
            //check to see if creating a new Message object properly sets the Name property of the class
            //how to grab the name within a new instance of a class?

            Message msg = new Message("This is the name");

            Assert.AreEqual(msg.Name, "This is the name");        
            

            //string message1InstanceName = message1.Name;

            //Assert.IsTrue(testName == message1.Name);
            //Assert.AreEqual(testName, message1.Name);
        }

        [TestMethod]
        public void ConstructorSetsCommandsField()
        {

            Message msg = new Message("Name", commands);

            Assert.AreEqual(commands, msg.Commands);

        }

    }
}