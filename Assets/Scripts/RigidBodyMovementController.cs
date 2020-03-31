using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RigidBodyMovementController : MonoBehaviour
{
    public Rigidbody rb;
    public float moveSpeed = 35f;
    public float sprintSpeedMultiplier = 1.6f;
    public float jumpForce = 35f;
    public LayerMask groundCheckLayerMask;
    public Transform groundCheckTransform;
    private Vector3 _inputVector;
    private bool _isGrounded = true;
    private Animator _anim;

    [SerializeField]
    private AudioSource _source;

    [SerializeField]
    private AudioSource _meow;

    [SerializeField]
    private Animator _UIController;


    private void Start()
    {
        _anim = GetComponent<Animator>();
        //_source = GetComponent<AudioSource>();
        _UIController.SetBool("Instruction", true);
    }

    void Update()
    {
        _inputVector = new Vector3(Input.GetAxis("Horizontal"), 0f, Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.LeftShift))
            _inputVector.z *= sprintSpeedMultiplier;

        if (Input.GetKeyDown(KeyCode.Space) && _isGrounded)
        {
            _meow.Play();
            rb.AddForce(jumpForce * 10 * transform.up, ForceMode.Impulse);
            _isGrounded = false;
            rb.mass = 5f;
        }
        else
        {
            rb.mass = 1f;
        }

        if (Input.GetButtonDown("Fire1"))
        {
            _anim.SetTrigger("Hit");
            _source.Play();
            _UIController.SetBool("Instruction", false);
        }
    }

    private void FixedUpdate()
    {
        _isGrounded = Physics.CheckSphere(groundCheckTransform.position, 0.3f, groundCheckLayerMask);

        Vector3 movement = moveSpeed * 10f * _inputVector.z * Time.fixedDeltaTime * transform.forward + moveSpeed * 10f * _inputVector.x * Time.fixedDeltaTime * transform.right;
        rb.MovePosition(rb.position + movement);
    }
}
