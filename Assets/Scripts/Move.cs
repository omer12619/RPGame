using RPG.Combat;
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
        NavMeshAgent agent;
        Ray lastray;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
        }

        void Update()
        {

          
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 local_velocotiy = transform.InverseTransformDirection(velocity);
            float speed = local_velocotiy.z;
            GetComponent<Animator>().SetFloat("forwardspeed", speed);
        }

        

        public void MoveTODestntion(Vector3 dest)
        {
           
            agent.destination = dest;
            agent.isStopped = false;

        }
        public void StartMoveAction(Vector3 dest) {
            GetComponent<Fighter>().unAttack();
            MoveTODestntion(dest);
        }
        public void StopMove()
        {
            agent.isStopped= true;
        }



    }
}

