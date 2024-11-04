// See https://aka.ms/new-console-template for more information

using System.Numerics;
using RobotWalker;

const string prompt =  @"Command the robot with:
  L - turn left
  R - turn right
  M - move forward
  ? - this message
  Q - quit";

var bounds = BoundingBox2D.FromMinMax(
    new Vector2(-10, -10),
    new Vector2(10, 10));

using(var boundsFile = File.OpenText("F:\\source\\interviews\\RobotWalker\\RobotWalker\\bounds.json"))
{
    var boundsJson = boundsFile.ReadToEnd();
    bounds = new BoundsParser().ParseFromJson(boundsJson);
    Console.WriteLine($"Bounds are {bounds}");
}

Console.WriteLine("Hello! Robot coming online.");
Console.WriteLine(prompt);

var walker = new RobotWalkerObject();
var keepPlaying = true;
while (keepPlaying)
{
    Console.Write("Enter a command: \n > ");
    var input = Console.ReadKey();
    Console.WriteLine();
    RobotWalkerCommand? command = null;
    // ReSharper disable once SwitchStatementHandlesSomeKnownEnumValuesWithDefault
    switch (input.Key)
    {
        case ConsoleKey.L:
            command = RobotWalkerCommand.TurnLeft;
            break;
        case ConsoleKey.R:
            command = RobotWalkerCommand.TurnRight;
            break;
        case ConsoleKey.M:
            command = RobotWalkerCommand.MoveForward;
            break;
        case ConsoleKey.Q:
            keepPlaying = false;
            break;
        case ConsoleKey.Oem2:
            Console.WriteLine(prompt);
            break;
        default:
            break;
    }
    
    if (command.HasValue)
    {
        var newWalker = walker.ExecuteCommand(command.Value);
        if (bounds.Contains(newWalker.Position.Point))
        {
            walker = newWalker;
        }
        else
        {
            Console.WriteLine("I can't go there!");
        }
        Console.WriteLine(walker.ToString());
    }
}