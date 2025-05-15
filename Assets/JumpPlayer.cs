using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPlayer : MonoBehaviour
{
    Rigidbody rb;
    NavMeshMovement NavMeshMovement;
    private bool jump = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        NavMeshMovement = GetComponent<NavMeshMovement>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Salto"))
        {

            Debug.Log("Hola");
            Trampolin tramp = collision.gameObject.GetComponent<Trampolin>();
            if (jump == true)
            {
                rb.angularVelocity = Vector3.zero;
                rb.velocity = Vector3.zero;
                rb.constraints = RigidbodyConstraints.FreezeRotation;
                NavMeshMovement.agent.enabled = false;
                rb.AddForce(tramp.fuerza, ForceMode.Impulse);
                jump = false;
            }

            else if (jump == false)
            {
                Debug.Log("Soy falso");
                NavMeshMovement.agent.enabled = true;
                jump = true;
            }


        }
    }


}
