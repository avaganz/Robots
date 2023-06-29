using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Robot : MonoBehaviour
{
    private Queue<Instruction> _instructions = new Queue<Instruction>();

    public void AddInstuction(Instruction instruction)
    {
        _instructions.Enqueue(instruction);
    }

    public void AddInstuctions(IEnumerable<Instruction> instructions)
    {
        foreach (var instruction in instructions)
            AddInstuction(instruction);
    }

    public void Run()
    {
        if (_instructions.Count > 0)
        {
            var instruction = _instructions.Dequeue();
            instruction.Completed += OnInstructionCompleted;
            instruction.ExecuteIn(gameObject);
        }
        else
        {
            Debug.Log("No instructions added");
        }
    }

    private void OnInstructionCompleted()
    {
        Run();
    }
}
