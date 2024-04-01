using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Door door;
    public Transform inFrontOfDoor;
    public Transform goal;
    Task main;
    void Build ()
    {
        Task openDoor = new OpenDoor(door);
        Task checkDoorClosed = new CheckForFalse(door.isOpen);
        Task checkDoorOpen = new CheckForTrue(door.isOpen);
        Task checkDoorNotLocked = new CheckForFalse(door.isLocked);
        Task goToRoom = new GoTo(transform, goal, 4f);
        var waitAfterBarge = new Wait(0.5f);
        var bargeColor = new ChangeColor(GetComponent<MeshRenderer>(), Color.red, 1f);
        var goToBarge = new GoTo(transform, door.transform, 1f);
        Task goToDoor = new GoTo(transform, inFrontOfDoor, 4f);

        Sequence doorOpen = new ();
        doorOpen.children.Add(checkDoorOpen);
        doorOpen.children.Add(goToRoom);
        doorOpen.behaviour = this;

        Sequence checkLock = new Sequence();
        checkLock.children.Add(checkDoorNotLocked);
        checkLock.children.Add(openDoor);
        checkLock.behaviour = this;

        Sequence checkBarge = new Sequence();
        checkBarge.children.Add(checkDoorClosed);
        checkBarge.children.Add(bargeColor);
        checkBarge.children.Add(goToBarge);
        checkBarge.children.Add(new Barge(door));
        checkBarge.children.Add(waitAfterBarge);
        checkBarge.behaviour = this;

        Selector checkDoor = new Selector();
        checkDoor.children.Add(checkLock);
        checkDoor.children.Add(checkBarge);
        checkDoor.behaviour = this;

        Sequence doorNotOpen = new Sequence();
        doorNotOpen.children.Add(goToDoor);
        doorNotOpen.children.Add(checkDoor);
        doorNotOpen.children.Add(goToRoom);
        doorNotOpen.behaviour = this;

        Selector mainSelector = new Selector();
        mainSelector.children.Add(doorOpen);
        mainSelector.children.Add(doorNotOpen);
        mainSelector.behaviour = this;
        
        main = mainSelector;
    }

    public void Run()
    {
        Build();

        main.CheckRequirements();
        StartCoroutine(main.Run());
    }
}
