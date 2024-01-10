using RPG.Combat;
using RPG.Core;
using RPG.Movement;
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {

        [SerializeField] float chaseDistance = 5f;
        [SerializeField] PatrolPath patrolPath;
        [SerializeField] float waypointTolreance=1f;
        [SerializeField] float waitatwaitpoint = 1f;
        GameObject player;

        Vector3 gurdLoaction;
        int waypoint;


        Fighter fighter;
        Health health;
        float timeSinceSawLastPlayer =Mathf.Infinity;
        [SerializeField] float timetoseppichose=3f;
        float timeAtWaypoint=0;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            gurdLoaction = transform.position;

            if(patrolPath != null)
            {
                 waypoint = 0;
            }
        }
        private void Update()
        {
            if (health.IsDead()) return;

            if (InRangeAttack() && fighter.CanAttack(player))
            {

                AttackBehaviour();
            }
            else if (timetoseppichose > timeSinceSawLastPlayer)
            {
                //Suspicion state
                SuspicionBehaviour();

            }
            else
            {
                PatrolBehaviour();
            }
            UpdateTimer();

        }

        private void UpdateTimer()
        {
            timeSinceSawLastPlayer += Time.deltaTime;
            timeAtWaypoint += Time.deltaTime;
        }

        private void PatrolBehaviour()
        {

            Vector3 nextPosition = gurdLoaction;
            if (patrolPath != null)
            {
                if (atWaypoint())
                {
                    if (timeAtWaypoint > waitatwaitpoint)
                    {
                        timeAtWaypoint = 0;
                        CycleWaypoint();
                    }
                }
                nextPosition = GetCurretWayPoint();


            }
            if(timeAtWaypoint > waitatwaitpoint)
            {
                Moveto(nextPosition);
            }
           
            
        }

        private void Moveto(Vector3 nextPosition)
        {
            
            GetComponent<Move>().StartMoveAction(nextPosition);
        }


        private bool atWaypoint()
        {
            
            
            float distancetoWaypoint = Vector3.Distance(transform.position, GetCurretWayPoint());
            if(distancetoWaypoint<waypointTolreance) {
                return true;
            }
            return false;
        }

        private void CycleWaypoint()
        {
            waypoint=GetNextIndex(waypoint);
        }

        private Vector3 GetCurretWayPoint()
        {
            return patrolPath.transform.GetChild(waypoint).position;

            
        }

        private void SuspicionBehaviour()
        {
            GetComponent<ActionSchedul>().CancelAction();
        }

        private void AttackBehaviour()
        {
            timeSinceSawLastPlayer = 0;
            fighter.Attack(player);
        }

        private bool InRangeAttack()
        {
            bool v = Vector3.Distance(player.transform.position, this.transform.position) < chaseDistance;
            
            
            return v;
        }

        //Called by unity
        private void OnDrawGizmosSelected()
        {
            Gizmos.color= Color.yellow;



            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
        private int GetNextIndex(int index)
        {
            if(index+1 == patrolPath.transform.childCount) { return 0; }
            
            return index + 1;
        }
        
      
    }
}


