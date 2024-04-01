using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barge : Task
{
    Door door;
    public Barge (Door door)
    {
        this.door = door;
    }

    public override bool CheckRequirements()
    {
        if (door == null) {
            return false; }
        return true;
    }

    public override IEnumerator Run ()
    {
        door.Barge();
        yield return null;
    }
}
