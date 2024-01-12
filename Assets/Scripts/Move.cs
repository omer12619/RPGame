
using RPG.Core;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Movement
{
    public class Move : MonoBehaviour ,IAction
    {
        [SerializeField] Transform target;
        [SerializeField] float maxspeed=6f;
        NavMeshAgent agent;
        Health health;
        Ray lastray;
        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            health = GetComponent<Health>();
        }

        void Update()
        {
            if (health.IsDead())
            {
                agent.enabled = false;
            }


          
            UpdateAnimator();
        }

        private void UpdateAnimator()
        {
            Vector3 velocity = agent.velocity;
            Vector3 local_velocotiy = transform.InverseTransformDirection(velocity);
            float speed = local_velocotiy.z;
            GetComponent<Animator>().SetFloat("forwardspeed", speed);
        }

        

        public void MoveTODestntion(Vector3 dest, float fraction)
        {
           
            agent.destination = dest;
            agent.speed = maxspeed * Mathf.Clamp01(fraction);
            agent.isStopped = false;

        }
        public void StartMoveAction(Vector3 dest, float fraction) {
            GetComponent<ActionSchedul>().StartAction(this);
            
            MoveTODestntion(dest, fraction);
           
        }
        public void Cancel()
        {
            agent.isStopped= true;
        }
       



    }
}

