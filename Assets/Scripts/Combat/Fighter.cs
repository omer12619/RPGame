using Newtonsoft.Json.Linq;
using RPG.Core;
using RPG.Movement;
using RPG.Saving;
using RPG.Attributes;
using UnityEngine;
using UnityEngine.AI;

namespace RPG.Combat
{
    public class Fighter : MonoBehaviour ,IAction  , IJsonSaveable
    {
        
        [SerializeField] float timeBetweenAttack = 1f;
        
       
        [SerializeField] Transform righthandTransform =null;
        [SerializeField] Transform lefthandTransform = null;
        [SerializeField] Weapon defaultweapon=null;
        
      
        
        Health target;
        float timeforlastattck = Mathf.Infinity;
        Weapon currentWeapon;


        // Start is called before the first frame update
        private void Start()
        {
            if (currentWeapon == null)
            {
                Equipeweapon(defaultweapon);


            }
        }

        // Update is called once per frame
        private void Update()
        {
            timeforlastattck += Time.deltaTime;
            if (target != null)
            {
                if (target.IsDead()) { return; }

                bool isInRange = Vector3.Distance(transform.position, target.transform.position) < currentWeapon.GetRangeOfAttack();

                if (target != null && !isInRange)
                {
                    GetComponent<Move>().MoveTODestntion(target.transform.position, 1f);
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

        public void Equipeweapon(Weapon weapon)
        {
           currentWeapon = weapon;
           Animator animator = GetComponent<Animator>();
           weapon.Spawn(righthandTransform,lefthandTransform,animator);
        }

        public void Attack(GameObject combattarget)
        {
            GetComponent<ActionSchedul>().StartAction(this);
            target = combattarget.GetComponent<Health>();
            
            
            
        }
        public void Cancel()
        {
            target = null;
            GetComponent<Move>().Cancel();
            StopAttack();

        }

        private void StopAttack()
        {
            if (target != null)
            {
                GetComponent<Animator>().SetTrigger("attack");
                GetComponent<Animator>().SetTrigger("StopAttack");
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
            if(currentWeapon.hasprojectile())
            {
                currentWeapon.LunchProjectile(righthandTransform,lefthandTransform,target);

            }
            else
            {
                target.TakeDamage(currentWeapon.GetDamage());

            }
            
            
        }

        void Shoot() {
            Hit();

        }
        public bool CanAttack(GameObject combatTarget)  
        {
            if (combatTarget == null) { return false; }
            Health targetToTest = combatTarget.GetComponent<Health>();
            return targetToTest != null && !targetToTest.IsDead();
        }

        public JToken CaptureAsJToken()
        {
            return JToken.FromObject(defaultweapon.name);
        }

        public void RestoreFromJToken(JToken state)
        {
            string weaponName = state.ToObject<string>();
            Weapon weapon = Resources.Load<Weapon>(weaponName);
            Equipeweapon(weapon);

        }
        public Health getTarget()
        {
            return target;
                
        }
    }
}
