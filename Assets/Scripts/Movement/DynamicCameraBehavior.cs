using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class DynamicCameraBehavior : MonoBehaviour
{
    [SerializeField] 
    private List<Transform> _targets;

    [SerializeField] 
    private Vector3 _offset;

    [SerializeField] 
    private float _smoothTime = 0.5f;
    [SerializeField] 
    private float _maxZoom = 40f;
    [SerializeField] 
    private float _minZoom = 0f;
    [SerializeField] 
    private float _zoomLimiter = 50f;

    private Vector3 _velocity = Vector3.zero;
    private Camera _cam;

    Vector3 GetCenterPoint()
    {
        //Guard clause
        //Returns position of player if there is only one
        if (_targets.Count == 1)
            return _targets[0].position;

        Bounds bounds = new Bounds(_targets[0].position, Vector3.zero);

        for (int i = 0; i < _targets.Count; i++)
            bounds.Encapsulate(_targets[i].position);

        return bounds.center;
    }

    float GetGreatestDistance()
    {
        Bounds bounds = new Bounds(_targets[0].position, Vector3.zero);
        for (int i = 0; i < _targets.Count; i++)
            bounds.Encapsulate(_targets[i].position);

        return bounds.size.x;
    }

    void CameraMove()
    {
        Vector3 centerPoint = GetCenterPoint();

        Vector3 newPosition = centerPoint + _offset;

        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref _velocity, _smoothTime);
    }

    void CameraZoom()
    {
        float newZoom = Mathf.Lerp(_maxZoom, _minZoom, GetGreatestDistance() / _zoomLimiter);
        _cam.fieldOfView = Mathf.Lerp(_cam.fieldOfView, newZoom, Time.deltaTime);
    }

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame after update is called
    void LateUpdate()
    {
        if (_targets.Count == 0)
            return;

        CameraMove();
        CameraZoom();
    }
}
