using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : Task
{
    MeshRenderer renderer;
    Color targetColor;
    float timeToChange;

    public ChangeColor (MeshRenderer renderer, Color targetColor, float timeToChange)
    {
        this.renderer = renderer;
        this.targetColor = targetColor;
        this.timeToChange = timeToChange;
    }
    public override bool CheckRequirements()
    {
        if (renderer == null) { return false; }
        return true;
    }

    public override IEnumerator Run()
    {
        Color color = renderer.material.color;
        float startTime = Time.time;
        float progress = 0;
        while (progress < 1f)
        {
            progress = (Time.time - startTime) / timeToChange;
            renderer.material.color = Color.Lerp(color, targetColor, progress);
            yield return new WaitForEndOfFrame();
        }
    }
}
