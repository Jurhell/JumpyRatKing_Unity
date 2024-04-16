using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody))]
public class BetterPlayerController : MonoBehaviour
{
    [SerializeField]
    private bool _isPlayer1;

    [SerializeField]
    private float _maxSpeed = 10;
    [SerializeField]
    private float _acceleration = 50;
    [SerializeField]
    private float _jumpHeight = 4;

    [Space]
    [SerializeField]
    private Vector3 _groundCheckPosition = new Vector3(0, -0.6f, 0);
    [SerializeField]
    private float _groundCheckRadius = 0.45f;

    private Rigidbody _rigidbody;
    private Vector3 _moveDirection;
    private bool _jumpInput = false;
    private bool _isGrounded = false;

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        if (_isPlayer1)
        {
        // Get movement force
        _moveDirection = new Vector3(Input.GetAxisRaw("Player1Horizontal"), 0, 0);
        _jumpInput = Input.GetAxisRaw("Player1Jump") != 0;
        }
        else
        {
            _moveDirection = new Vector3(Input.GetAxisRaw("Player2Horizontal"), 0, 0);
            _jumpInput = Input.GetAxisRaw("Player2Jump") != 0;
        }
    }

    void FixedUpdate()
    {
        // Ground check
        _isGrounded = Physics.OverlapSphere(transform.position + _groundCheckPosition, _groundCheckRadius).Length > 1;

        // Add movement force
        _rigidbody.AddForce(_moveDirection * _acceleration * Time.fixedDeltaTime, ForceMode.VelocityChange);

        // Clamp velocity to max speed
        Vector3 velocity = _rigidbody.velocity;
        float newXSpeed = Mathf.Clamp(_rigidbody.velocity.x, -_maxSpeed, _maxSpeed);
        velocity.x = newXSpeed;
        _rigidbody.velocity = velocity;

        // Add jump force
        if (_jumpInput && _isGrounded)
        {
            // Calculate force needed to reach _jumpHeight
            float force = Mathf.Sqrt(_jumpHeight * -2f * Physics.gravity.y);
            _rigidbody.AddForce(Vector3.up * force, ForceMode.Impulse);
        }
    }

#if UNITY_EDITOR
    void OnDrawGizmosSelected()
    {
        // Draw ground check
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + _groundCheckPosition, _groundCheckRadius);
    }
#endif
}
