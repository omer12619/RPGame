using RPG.Combat;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;




namespace RPG.Control
{
    public class AIController : MonoBehaviour
    {

        [SerializeField] float chaseDistance = 5f;
        GameObject player;


        Fighter fighter;

        private void Start()
        {
            player = GameObject.FindWithTag("Player");
            fighter = GetComponent<Fighter>();
        }
        private void Update()
        {

            if (InRangeAttack() && fighter.CanAttack(player))
            {
               fighter.Attack(player);
            }
            else
            {
                fighter.Cancel(); 
            }

        }

        private bool InRangeAttack()
        {
            bool v = Vector3.Distance(player.transform.position, this.transform.position) < chaseDistance;
            return v;
        }
    }
}


