using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private GameObject _planet;
    [SerializeField] private Rigidbody _rigidbody;

    public float Speed = 4;
    public float JumpHeight = 1.2f;


    void Update()
    {
        float xMove = Input.GetAxis("Horizontal") * Time.deltaTime * Speed;
        float zMove = Input.GetAxis("Vertical") * Time.deltaTime * Speed;

        transform.Translate(xMove, 0, zMove);

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(0, 150 * Time.deltaTime, 0);
        }

        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(0, -150 * Time.deltaTime, 0);
        }

        Vector3 gravityDirection = (transform.position - _planet.transform.position).normalized;

        _rigidbody.AddForce(gravityDirection * -100);

        Quaternion toRotate = Quaternion.FromToRotation(transform.up, gravityDirection) * transform.rotation;
        transform.rotation = toRotate;
    }
}