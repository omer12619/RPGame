using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Core
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float health = 100;
        bool die = false;

        public bool IsDead()
        {
            return die;
        }

        // Start is called before the first frame update
        public void TakeDamage(float damage)
        {
            
            if (health > 0)
            {
                health -= damage;
            }
            if(health <= 0)
            {
                health = 0;
                triggerDieAnimtion();
                
            }
        }

        // Update is called once per frame
        void Update()
        {
            

        }
        void triggerDieAnimtion()
        {
            if (!die)
            {
                die = true;
                GetComponent<CapsuleCollider>().enabled = false;
                GetComponent<Animator>().SetTrigger("Death");
               
                GetComponent<ActionSchedul>().CancelAction();
            }
        }

    }
}
