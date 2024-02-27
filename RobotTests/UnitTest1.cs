using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RobotBAL;

namespace RobotTests
{
[TestClass]
public class clsRobotTests
{
    [TestMethod]
    public void NotPlacedYet()
    {
        
        clsRobot robot = new clsRobot();
        string result = robot.command("REPORT");
        Assert.AreEqual(clsRobot.NOT_PLACED_YET_MESSAGE, result);
    }

    [TestMethod]
    public void AfterPlaced()
    {
         
        clsRobot robot = new clsRobot();
        string result = robot.command("PLACE 0,0,NORTH");
        Assert.AreEqual(string.Empty, result);
    }
       
        [TestMethod]
        public void ProvidedTest1()
        {
            clsRobot robot = new clsRobot();
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("MOVE");
            result = robot.command("REPORT");
            Assert.AreEqual("0,1,NORTH", result);
        }


        // ************** Test left direction ********************************************
        [TestMethod]
        public void ProvidedTest2()
        {
            
            clsRobot robot = new clsRobot();
          
            string result = robot.command("PLACE 0,0,NORTH");
            result = robot.command("LEFT");
            result = robot.command("REPORT");
            //assert
            Assert.AreEqual("0,0,WEST", result);
        }

    }
}