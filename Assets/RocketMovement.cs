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

    void FixedUpdate()
    {
        RocketThrusting();
        RocketSteering();
    }
    private void RocketThrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {            
            rigidBody.AddRelativeForce(Vector3.up * boostForce * Time.deltaTime);
            if (isThrusted) { return; }
            isThrusted = true;
        }
        else { isThrusted = false; }

        ThrustingSFX();
    }

    private void RocketSteering()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * steeringSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.forward * -steeringSpeed * Time.deltaTime);
        }
    }

    private void ThrustingSFX()
    {
        if (isThrusted) { audioSource.Play(); }
        else { audioSource.Stop(); }
    }

   
}
