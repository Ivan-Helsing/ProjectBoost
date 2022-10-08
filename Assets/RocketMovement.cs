using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [SerializeField] float boostForce;
    [SerializeField] float steeringSpeed;

    public bool isThrusted = false;

    Rigidbody rigidBody;
    AudioSource audioSource;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rigidBody.AddRelativeForce(Vector3.up * boostForce * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * steeringSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -steeringSpeed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.Space)) { isThrusted = true; }
        if (Input.GetKeyUp(KeyCode.Space)) { isThrusted = false; }
        if (isThrusted) { audioSource.enabled = true; } else { audioSource.enabled = false; }
    }
}
