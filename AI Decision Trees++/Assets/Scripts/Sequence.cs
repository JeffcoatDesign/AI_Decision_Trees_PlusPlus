using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sequence : Task
{
    public MonoBehaviour behaviour;
    public List<Task> children = new();

    public override bool CheckRequirements()
    {
        if (behaviour == null) return false;
        foreach (var child in children)
        {
            if (!child.CheckRequirements())
                return false;
        }
        return true;
    }

    public override IEnumerator Run()
    {
        foreach (var child in children)
        {
            yield return behaviour.StartCoroutine(child.Run());
        }
    }
}
