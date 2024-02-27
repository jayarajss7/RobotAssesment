using RobotAssesment;
using RobotBAL;

namespace RobotAssesment
{
    class Program
    {
        static void Main(string[] args)
        {
            string inputCommand = String.Empty;

            clsRobot robot = new clsRobot();

            Console.WriteLine("Robot initialised. Enter commands to send to Robot: (X at any time to quit)");

            while (true)
            {
                Console.WriteLine("Enter command for Robot:");
                inputCommand = Console.ReadLine();

                if (inputCommand.ToUpper().Equals("X"))
                    break;

                Console.WriteLine(robot.command(inputCommand));
                Console.WriteLine();
            }
            Console.WriteLine("Exited - press any key to close");
            Console.ReadLine();
        }
    }
}