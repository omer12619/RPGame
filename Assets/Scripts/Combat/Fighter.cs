using RPG.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour
    {
        [SerializeField] float RangeOfAttack =2f;
        Transform target;

        // Start is called before the first frame update
        public void Attack(CombatTarget combattarget)
        {
            target = combattarget.transform;
            
            
        }
        public void unAttack()
        {
            target = null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (target != null)
            {

                bool isInRange = Vector3.Distance(transform.position, target.position) < RangeOfAttack;

                if (target != null && !isInRange)
                {
                    GetComponent<Move>().MoveTODestntion(target.position);
                }
                else
                {
                    GetComponent<Move>().StopMove();
                }
            }


        }
    }
}
