using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen;
    public bool isLocked;

    private void Start()
    {
        if (isOpen)
            transform.rotation = Quaternion.Euler(0, 75, 0);
    }

    public void Barge()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, 100, -10), ForceMode.VelocityChange);
    }

    public IEnumerator Open () {
        if (!isLocked)
        {
            while (transform.rotation.eulerAngles.y < 75)
            {
                transform.Rotate(0f, 0.5f, 0f);
                yield return new WaitForEndOfFrame();
            }
            transform.rotation = Quaternion.Euler(0, 75, 0);
            isOpen = true;
        }
    }

    public void SetIsOpen(bool isOpen)
    {
        this.isOpen = isOpen;
        if (isOpen) transform.rotation = Quaternion.Euler(0, 75, 0);
        else transform.rotation = Quaternion.identity;
    }

    public void SetIsLocked (bool isLocked) => this.isLocked = isLocked;
}
