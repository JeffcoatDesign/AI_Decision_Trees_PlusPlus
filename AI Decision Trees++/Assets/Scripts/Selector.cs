using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Task
{
    public MonoBehaviour behaviour;
    public List<Task> children = new();
    Task selectedTask = null;

    public override bool CheckRequirements()
    {
        foreach (var child in children)
        {
            if (child.CheckRequirements())
            {
                selectedTask = child;
                return true;
            }
        }
        return false;
    }

    public override IEnumerator Run()
    {
        yield return behaviour.StartCoroutine(selectedTask.Run());
    }

}
