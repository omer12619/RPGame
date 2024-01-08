using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Move : MonoBehaviour
{
    [SerializeField] Transform target;
    Ray lastray;
    
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            MoveTOcursor();

        }
        UpdateAnimator();
    }

    private void UpdateAnimator()
    {
       Vector3 velocity =GetComponent<NavMeshAgent>().velocity;
        Vector3 local_velocotiy = transform.InverseTransformDirection(velocity);
        float speed = local_velocotiy.z;
        GetComponent<Animator>().SetFloat("forwardspeed", speed);
    }

    private void MoveTOcursor()
        {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        bool hashit =Physics.Raycast(ray,out hit); 
        if (hashit)
        {
            GetComponent<NavMeshAgent>().destination= hit.point;
        }
            
            
            }


        

    }

