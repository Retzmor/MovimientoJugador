using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
    [SerializeField] Camera currentCamera;
    [SerializeField] LayerMask deteccionLayer;
    RaycastHit hit;
    public delegate void InputEventDelegate(RaycastHit hit);
    public InputEventDelegate CollisionDetectedEvent;

    public static InputController Instance;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
           Ray ray = currentCamera.ScreenPointToRay(Input.mousePosition);
           
            if(Physics.Raycast(ray, out hit, Mathf.Infinity, deteccionLayer))
            {
                CollisionDetectedEvent?.Invoke(hit);
            }
        }
    }
}
