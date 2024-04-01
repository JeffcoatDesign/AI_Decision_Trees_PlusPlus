using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Task
{
    public abstract bool CheckRequirements();
    public abstract IEnumerator Run();
}