using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : Task
{
    float waitTime;
    public Wait (float waitTime)
    {
        this.waitTime = waitTime;
    }
    public override bool CheckRequirements() => true;

    public override IEnumerator Run()
    {
        yield return new WaitForSeconds(waitTime);
    }
}
