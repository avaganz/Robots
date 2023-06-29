using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command : MonoBehaviour
{
    public Action Completed { get; set; }

    public float Runtime { get; set; }

    public virtual void ExecuteIn(GameObject obj)
    {

    }
}
