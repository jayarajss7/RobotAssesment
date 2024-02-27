using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotBAL
{
    public class clsRobot
    {
        public const string OUT_OF_BOUNDS_MESSAGE = "Command ignored - out of bounds";
        public const string NOT_PLACED_YET_MESSAGE = "Command ignored - robot not placed yet";
        public const string COMMAND_NOT_RECOGNISED_MESSAGE = "Command ignored - robot did not understand this command";
        public const string VALID_COMMANDS_MESSAGE = "Error during command handling.\nValid commands are:\nPLACE X,Y,Z\nMOVE\nLEFT\nRIGHT\nREPORT";

        private const int xLowerBoundary = 0;
        private const int yLowerBoundary = 0;

        private int xUpperBoundary = -1;
        private int yUpperBoundary = -1;
        private int xPosition = -1;
        private int yPosition = -1;
        private string direction = string.Empty;
        private bool isPlaced = false;
        public clsRobot()
        {
            xUpperBoundary = 5;
            yUpperBoundary = 5;
        }
        public clsRobot(int tableSizeX, int tableSizeY)
        {
            xUpperBoundary = tableSizeX;
            yUpperBoundary = tableSizeY;
        }
        private string reportVal()
        {
            return xPosition + "," + yPosition + "," + direction;
        }
        private bool validatePosition()
        {
            if ((xPosition < xLowerBoundary) || (yPosition < yLowerBoundary))
                return false;
            else if ((xPosition > xUpperBoundary) || (yPosition > yUpperBoundary))
                return false;
            else
                return true;
        }
        private string place(string command)
        {
            string result = string.Empty;
            char[] delimiterChars = { ',', ' ' };
            string[] wordsInCommand = command.Split(delimiterChars);

            xPosition = Int32.Parse(wordsInCommand[1]);
            yPosition = Int32.Parse(wordsInCommand[2]);
            direction = wordsInCommand[3];

            if (!validatePosition())
                result = OUT_OF_BOUNDS_MESSAGE;
            else
                isPlaced = true;

            return result;
        }
        private string objectmove()
        {
            string result = string.Empty;
            int originalX = this.xPosition;
            int originalY = this.yPosition;

            switch (direction)
            {
                case "NORTH":
                case "N":
                    yPosition++; break;
                case "WEST":
                case "W":
                    xPosition--; break;
                case "SOUTH":
                case "S":
                    yPosition--; break;
                case "EAST":
                case "E":
                    xPosition++; break;
            }

            if (!validatePosition())
            {
                xPosition = originalX;
                yPosition = originalY;
                result = OUT_OF_BOUNDS_MESSAGE;
            }
            return result;
        }

        private void objectleft()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "WEST"; break;
                case "WEST":
                case "W":
                    direction = "SOUTH"; break;
                case "SOUTH":
                case "S":
                    direction = "EAST"; break;
                case "EAST":
                case "E":
                    direction = "NORTH"; break;
            }
        }

        private void objectright()
        {
            switch (direction)
            {
                case "NORTH":
                case "N":
                    direction = "EAST"; break;
                case "E":
                case "EAST":
                    direction = "SOUTH"; break;
                case "S":
                case "SOUTH":
                    direction = "WEST"; break;
                case "W":
                case "WEST":
                    direction = "NORTH"; break;
            }
        }

        public string command(string input)
        {
            string command = input.ToUpper();
            string result = string.Empty;

            try
            {
                if (command.Contains("PLACE"))
                    result = place(command);

                else if (!isPlaced)
                    result = NOT_PLACED_YET_MESSAGE;

                else if (command.Contains("REPORT"))
                    result = reportVal();

                else if (command.Contains("MOVE"))
                    result = objectmove();

                else if (command.Contains("LEFT"))
                    objectleft();

                else if (command.Contains("RIGHT"))
                    objectright();

                else
                    result = COMMAND_NOT_RECOGNISED_MESSAGE;
            }
            catch (Exception e)
            {
                result = VALID_COMMANDS_MESSAGE;
            }

            return result;
        }
    }
}
