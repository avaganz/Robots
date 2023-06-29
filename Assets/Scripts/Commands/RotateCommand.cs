using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCommand : Command
{
    public Vector3 Target { get; set; }

    public float Angle { get; set; }

    public override void ExecuteIn(GameObject obj)
    {
        var component = obj.AddComponent<RotateCommand>();
        component.Runtime = Runtime;
        component.Target = Target;
        component.Angle = Vector3.Distance(obj.transform.eulerAngles, Target);
        component.Completed = Completed;
    }

    private void Update()
    {
        if (Vector3.Distance(transform.eulerAngles, Target) > 0.001f)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, 
                                                          Quaternion.Euler(Target),
                                                          Angle / Runtime * Time.deltaTime);
        }
        else
        {
            transform.eulerAngles = Target;

            if (Completed != null)
                Completed.Invoke();

            Destroy(this);
        }
    }
}
