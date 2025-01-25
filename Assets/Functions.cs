using System.Collections.Generic;
using System;
using UnityEngine;

public class Functions : MonoBehaviour
{
    public float startX = 0f;
    public float startY = 0f;

    public List<MathFunction> stack = new List<MathFunction>();

    public void AddSatck(MathFunction newStep)
    {
        newStep.originX = startX;
        stack.Add(newStep);
    }

    public void ResetStack()
    {
        stack.Clear();
    }

    public float RunAway(float x)
    {
        float y = startY;
        for (int i = 0; i < stack.Count; i++)
        {
            y += stack[i].execute(x);
        }

        return y;

    }
}
