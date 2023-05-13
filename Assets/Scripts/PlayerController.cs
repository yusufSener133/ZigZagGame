using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public bool startGame;
    public int _score = 0;
    [SerializeField] GroundSpawner _groundSpawner;
    [SerializeField] ChangeColor _changeColor;
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
            startGame = true;
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
            _rigidbody.velocity = new Vector3(yon.x * _moveSpeed, _rigidbody.velocity.y, yon.z * _moveSpeed);
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Zemin"))
        {
            _groundSpawner.ZeminOlustur();
            if (_score % 3 == 0)
                _moveSpeed += .2f;
            StartCoroutine(Yoket(collision.transform));
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            _score++;
            Destroy(other.gameObject);
        }
    }
    IEnumerator Yoket(Transform go)
    {
        yield return new WaitForSeconds(.3f);
        if (!go.GetComponent<Rigidbody>())
        {
            go.gameObject.AddComponent<Rigidbody>();
        }
        yield return new WaitForSeconds(1f);
        go.tag = "Untagged";
        Destroy(go.gameObject, 2f);
    }
}
