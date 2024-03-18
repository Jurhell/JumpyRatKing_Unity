using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Makes it so rigidbody will never be null.
//Also will add rigidbody component to inspector when including this class as component.
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField, Min(0), Tooltip("Player Speed")] private float _speed = 50;

    [SerializeField, Min(0), Tooltip("How much vertical force is applied when jumping")] 
    private float _jumpForce = 50;

    //Makes it so this variable appears in inspector
    [SerializeField]
    //Sets the minimum value for this value in inspector
    [Min(0)]
    //Creates a slider with these values in inspector
    [Range(0, 100)]
    //Creates a tooltip for variable in inspector
    [Tooltip("This is for reference purposes")]
    private float _placeholder;

    private Rigidbody _rigidbody;
    private bool _isGrounded = false;

    public float Speed
    {
        //Lambda (=>) declares only one line, also works for functions
        get => _speed;
        set => _speed = Mathf.Max(0, value);
    }

    // Runs when the scene is constructed.
    // Makes it so start function is called and rigidbody is not null even if player controller isn't enabled.
    private void Awake()
    {
        Debug.Log("Awake");

        //Get refernce to rigidbody
        _rigidbody = GetComponent<Rigidbody>();
        Debug.Assert(_rigidbody, "Rigidbody is null!");

        /*The same as the assert function above
        //if (_rigidbody == null)
        //    Debug.LogError("Rigidbody is null!");*/
    }

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        float jumpInput = 0;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            jumpInput = 1;
            _isGrounded = false;
        }

        _rigidbody.AddForce(Vector3.right * moveInput * _speed * Time.deltaTime);
        _rigidbody.AddForce(Vector3.up * jumpInput * _jumpForce * Time.deltaTime, ForceMode.Impulse);

    }

    void OnTriggerEnter(Collider other)
    {
        _isGrounded = true;
    }
}
