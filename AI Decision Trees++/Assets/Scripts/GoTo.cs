using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoTo : Task
{
    float timeToTarget;
    Transform character;
    Transform target;
    public GoTo (Transform character, Transform target, float timeToTarget)
    {
        this.character = character;
        this.target = target;
        this.timeToTarget = timeToTarget;
    }

    public override bool CheckRequirements()
    {
        if (character == null || target == null) return false;
        return true;
    }

    public override IEnumerator Run()
    {
        float startTime = Time.time;
        while (Vector3.Distance(character.position, target.position) > 0.05f) {
            float progress = (Time.time - startTime) / timeToTarget;
            character.position = Vector3.Lerp(character.position, target.position, progress);
            yield return new WaitForEndOfFrame();   
        }
        yield return null;
    }
}
