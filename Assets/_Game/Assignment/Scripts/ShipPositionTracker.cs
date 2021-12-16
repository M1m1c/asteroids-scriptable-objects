using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPositionTracker : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        var x = transform.position.x;
        var y = transform.position.y;
        var newX = x;
        var newY = y;

        var outOfBoundsX = x > 11f || x < -11f;
        var outOfBoundsY = y > 6.5f || y < -6.5f;

        if (outOfBoundsX)
        {
            newX = x > 0 ? -10f : 10f;            
        }

        if (outOfBoundsY)
        {
            newY = y > 0 ? -6f : 6f;
        }

        if (outOfBoundsX || outOfBoundsY)
        {
            this.transform.position = new Vector3(newX, newY, 0f);
        }
       
    }
}
