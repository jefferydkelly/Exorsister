using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleController : ClickableObject
{
    Vector3 startPosition;


    private void Awake()
    {
        startPosition = transform.position;
    }

    public override void OnDrag(Vector3 vec)
    {
        transform.position = Camera.main.ScreenToWorldPoint(vec.SetZ(-Camera.main.transform.position.z));
    }
    public override void OnUnclick()
    {
        transform.position = startPosition;
    }
}
