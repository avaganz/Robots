using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColorCommand : Command
{
    public Color Target { get; set; }

    private Renderer _renderer;

    public override void ExecuteIn(GameObject obj)
    {
        var component = obj.AddComponent<ChangeColorCommand>();
        component.Runtime = Runtime;
        component.Target = Target;
        component.Completed = Completed;
    }

    private void Start()
    {
        _renderer = GetComponent<Renderer>();

        if (_renderer == null)
        {
            if (Completed != null)
                Completed.Invoke();

            Destroy(this);
        }
    }

    private void Update()
    {
        if (_renderer)
        {
            if (_renderer.material.color != Target)
            {
                _renderer.material.color = Color.Lerp(_renderer.material.color, Target, Time.deltaTime / Runtime);
                Runtime -= Time.deltaTime;
            }
            else
            {
                if (Completed != null)
                    Completed.Invoke();

                Destroy(this);
            }
        }
    }
}
