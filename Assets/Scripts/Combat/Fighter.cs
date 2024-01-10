using RPG.Core;
using RPG.Movement;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour ,IAction
    {
        [SerializeField] float RangeOfAttack =2f;
        [SerializeField] float timeBetweenAttack = 1f;
        [SerializeField] float weaponDamage = 1f;
        Health target;
        float timeforlastattck = 0f;

        // Start is called before the first frame update
        public void Attack(CombatTarget combattarget)
        {
            GetComponent<ActionSchedul>().StartAction(this);
            target = combattarget.GetComponent<Health>();
            
            
            
        }
        public void Cancel()
        {
            target = null;
            StopAttack();

        }

        private void StopAttack()
        {
            GetComponent<Animator>().SetTrigger("attack");
            GetComponent<Animator>().SetTrigger("StopAttack");
        }

        // Update is called once per frame
        private void Update()
        {
            timeforlastattck+= Time.deltaTime;
            if (target != null)
            {
                if (target.IsDead()) { return; }

                bool isInRange = Vector3.Distance(transform.position, target.transform.position) < RangeOfAttack;

                if (target != null && !isInRange)
                {
                    GetComponent<Move>().MoveTODestntion(target.transform.position);
                }
                else
                {
                    GetComponent<Move>().Cancel();
                    if (timeBetweenAttack < timeforlastattck)
                    {
                        AttackBehaviour();
                        timeforlastattck = 0f;
                    }
                }
            }


        }
        void AttackBehaviour()
        {
            transform.LookAt(target.transform);
            //this trigger hit event
            TriggerAttack();

        }

        private void TriggerAttack()
        {
            GetComponent<Animator>().ResetTrigger("StopAttack");
            GetComponent<Animator>().SetTrigger("attack");
        }

        void Hit()
        {
            if (target == null) { return; }
            
            target.TakeDamage(weaponDamage);
        }
        public bool CanAttack()
        {
            if (target != null&& !target.IsDead()) {
                return true;
            }
            return false;
        }
        
    }
}
