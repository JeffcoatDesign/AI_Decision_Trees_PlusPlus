using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForTrue : Task
{
    bool value;
    public CheckForTrue (bool value)
    {
        this.value = value;
    }

    public override bool CheckRequirements()
    {
        return value;
    }

    public override IEnumerator Run()
    {
        yield return null;
    }
}