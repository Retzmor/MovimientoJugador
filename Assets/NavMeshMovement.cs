using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class NavMeshMovement : MonoBehaviour
{

    public NavMeshAgent agent;
    [SerializeField] Transform target;
    Rigidbody rb;
    
    
    
    public void OnEnable()
    {
        InputController.Instance.CollisionDetectedEvent +=SetTargetPosition;
    }

    public void OnDisable()
    {
        InputController.Instance.CollisionDetectedEvent -= SetTargetPosition;
    }

    public void SetTargetPosition(RaycastHit hit)
    {
        target.position = hit.point;
    }

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        rb = GetComponent<Rigidbody>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(agent.enabled)
        {
            agent.SetDestination(target.position);
        }  
    }

    

}
