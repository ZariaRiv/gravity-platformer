using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerLimited : Player
{
    // Update is called once per frame
    public override void Update()
    {
        Move();
        MenuInputs();
    }
}