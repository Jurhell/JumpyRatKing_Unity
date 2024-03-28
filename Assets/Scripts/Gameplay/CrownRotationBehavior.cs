using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrownRotationBehavior : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, -1f, 0f, Space.Self);
    }
}
