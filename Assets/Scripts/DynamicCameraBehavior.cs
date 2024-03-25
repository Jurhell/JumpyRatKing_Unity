using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynamicCameraBehavior : MonoBehaviour
{
    [SerializeField] private float _depthUpdateSpeed = 5f;
    [SerializeField] private float _angleUpdateSpeed = 7f;
    [SerializeField] private float _positionUpdateSpeed = 5f;

    [SerializeField] private float _depthMax = -10f;
    [SerializeField] private float _depthMin = -22f;

    [SerializeField] private float _angleMax = 11f;
    [SerializeField] private float _angleMin = 3f;

    private float _cameraRulerX;
    private Vector3 _cameraPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
