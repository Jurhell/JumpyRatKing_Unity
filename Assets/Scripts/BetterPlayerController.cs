using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BetterPlayerController : MonoBehaviour
{
    [SerializeField]
    private float _maxSpeed;
    [SerializeField]
    private float _acceleration;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get movement force
        _moveDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0, 0);
    }

    void FixedUpdate()
    {
        // Add movement force
        _rigidbody.AddForce(_moveDirection * _acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Clamp velocity to max speed
        if (_rigidbody.velocity.magnitude > _maxSpeed)
            _rigidbody.velocity = _rigidbody.velocity.normalized * _maxSpeed;
    }
}
