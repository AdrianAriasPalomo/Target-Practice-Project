using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckBehavior : TargetBehavior
{
    private float moveSpeed = 3;
    private float border = 2;

    protected override void Move()
    {
        // Override parent class method to move left and right.
        transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);

        if (Mathf.Abs(transform.position.x - originalPos.x) > border)
        {
            moveSpeed *= -1;
        }
    }
}
