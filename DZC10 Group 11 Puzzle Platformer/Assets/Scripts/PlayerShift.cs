using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerShift : Player
{
    
    // Override of Player.Move() to prevent movement
    public override void Move()
    {
        // Left this empty to prevent movement, not a best practise but it works
    }
}
