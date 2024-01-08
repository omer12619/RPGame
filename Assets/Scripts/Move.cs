using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Move : MonoBehaviour
    {
        [SerializeField] Transform target;
        Ray lastray;

        void Update()
        {

          
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = GetComponent<NavMeshAgent>().velocity;
            Vector3 local_velocotiy = transform.InverseTransformDirection(velocity);
            float speed = local_velocotiy.z;
            GetComponent<Animator>().SetFloat("forwardspeed", speed);
        }

        

        public void MoveTODestntion(Vector3 dest)
        {
            GetComponent<NavMeshAgent>().destination = dest;
        }



    }
}

