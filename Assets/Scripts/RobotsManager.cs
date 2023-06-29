using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotsManager : MonoBehaviour
{
    [SerializeField]
    private Robot _prefab;

    private List<Robot> _robots = new List<Robot>();

    private void Start()
    {
        InitRobot();
    }

    private void InitRobot()
    {
        var instructions = GetInstructions();

        var robot = Instantiate(_prefab, transform);
        robot.AddInstuctions(instructions);
        robot.Run();

        _robots.Add(robot);
    }

    private IEnumerable<Instruction> GetInstructions()
    {
        var instructions = new Queue<Instruction>();

        // instruction 1
        {
            var instruction = new Instruction();

            // command A
            {
                var moveCommand = new MoveCommand();
                moveCommand.Runtime = 2f;
                moveCommand.Target = new Vector3(5f, 0f, 0f);
                instruction.AddCommand(moveCommand);
            }
            // command B
            {
                var rotateCommand = new RotateCommand();
                rotateCommand.Runtime = 2f;
                rotateCommand.Target = new Vector3(90f, 0f, 0f);
                instruction.AddCommand(rotateCommand);
            }
            // command C
            {
                var moveCommand = new MoveCommand();
                moveCommand.Runtime = 2f;
                moveCommand.Target = new Vector3(5f, 5f, 0f);
                instruction.AddCommand(moveCommand);
            }

            instructions.Enqueue(instruction);
        }
        
        // instruction 2
        {
            var instruction = new Instruction();

            // command A
            {
                var rotateCommand = new RotateCommand();
                rotateCommand.Runtime = 2f;
                rotateCommand.Target = new Vector3(45f, 45f, 45f);
                instruction.AddCommand(rotateCommand);
            }
            // command B
            {
                var colorCommand = new ChangeColorCommand();
                colorCommand.Runtime = 2f;
                colorCommand.Target = new Color(1f, 0f, 0f, 1f);
                instruction.AddCommand(colorCommand);
            }
            // command C
            {
                var moveCommand = new MoveCommand();
                moveCommand.Runtime = 2f;
                moveCommand.Target = new Vector3(5f, 5f, 0f);
                instruction.AddCommand(moveCommand);
            }

            instructions.Enqueue(instruction);
        }
        
        return instructions;
    }
}
