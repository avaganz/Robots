using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCommand : Command
{
    public Vector3 Target { get; set; }

    public float Distance { get; set; }

    public override void ExecuteIn(GameObject obj)
    {
        var component = obj.AddComponent<MoveCommand>();
        component.Runtime = Runtime;
        component.Target = Target;
        component.Distance = Vector3.Distance(obj.transform.position, Target);
        component.Completed = Completed;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, Target) > 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, Target, Distance / Runtime * Time.deltaTime);
        }
        else
        {
            transform.position = Target;

            if (Completed != null)
                Completed.Invoke();

            Destroy(this);
        }
    }
}
