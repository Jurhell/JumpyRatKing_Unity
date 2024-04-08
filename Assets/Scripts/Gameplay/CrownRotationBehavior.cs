using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownRotationBehavior : MonoBehaviour
{
    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0f, 3f, 0f, Space.Self);
    }
}
