using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instruction
{
    private Queue<Command> _commands = new Queue<Command>();

    public Action Completed { get; set; }

    private GameObject _root;

    public void AddCommand(Command command)
    {
        _commands.Enqueue(command);
    }

    public void ExecuteIn(GameObject obj)
    {
        _root = obj;

        if (_commands.Count > 0)
        {
            var command = _commands.Dequeue();
            command.Completed += OnCommandCompleted;
            command.ExecuteIn(obj);
        }
        else
        {
            Completed.Invoke();
        }
    }

    private void OnCommandCompleted()
    {
        ExecuteIn(_root);
    }
}
