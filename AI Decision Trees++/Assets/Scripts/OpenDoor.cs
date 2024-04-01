using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : Task
{
    Door door;

    public OpenDoor(Door door)
    {
        this.door = door;
    }

    public override bool CheckRequirements()
    {
        if (door == null) return false;
        return true;
    }

    public override IEnumerator Run()
    {
        Debug.Log("Opening door");
        yield return door.StartCoroutine(door.Open());
    }
}
