
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Move : MonoBehaviour ,IAction
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
            GetComponent<ActionSchedul>().StartAction(this);
            
            MoveTODestntion(dest);
           
        }
        public void Cancel()
        {
            agent.isStopped= true;
        }
       



    }
}

