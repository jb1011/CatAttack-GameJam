using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody _rb;
    private float MoveHorizontal;
    private float MoveVertical;

    private Vector3 direction;

    [SerializeField]
    private float _speed;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private Camera Camera_main;



    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        MoveHorizontal = Input.GetAxis("Horizontal");
        MoveVertical = Input.GetAxis("Vertical");

        //pour le mouvement
        //direction = new Vector3(MoveHorizontal, 0, MoveVertical);
        //_rb.AddForce(direction.normalized * Time.fixedDeltaTime * _speed, ForceMode.Impulse);
        direction = (transform.forward * MoveVertical) + (transform.right * MoveHorizontal);

        _rb.MovePosition(_rb.position + direction * _speed * Time.fixedDeltaTime);


        if (MoveVertical > 0 || MoveVertical < 0)
        {
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera_main.transform.localEulerAngles.y, transform.localEulerAngles.z);
        }
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            _rb.AddForce(new Vector3(0, _jumpForce, 0), ForceMode.Impulse);
        }
    }
}
