using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool startGame;
    [SerializeField, Range(0, 10)] float _moveSpeed = 3f;
    Vector3 yon = Vector3.left;
    Rigidbody _rigidbody;
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (yon.x == 0)
            {
                yon = Vector3.left;
            }
            else
            {
                yon = Vector3.back;
            }
        }
    }
    private void FixedUpdate()
    {
        if (startGame)
        {
            _rigidbody.velocity = yon * _moveSpeed;
        }
        else
        {
            _rigidbody.velocity = Vector3.zero;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {

        }
    }
}
