using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Newtonsoft.Json.Linq;
using RPG.Saving;
using RPG.Combat;
using RPG.Core;
using RPG.Stats;


namespace RPG.Attributes
{
    public class Health : MonoBehaviour, IJsonSaveable
    {
        [SerializeField] float health = 100;
        bool die = false;





        private void Start()
        {
            health= GetComponent<BaseStats>().GetStat(Statis.Health);
        }

        public bool IsDead()
        {
            
            return die;
        }

        // Start is called before the first frame update
        public void TakeDamage(GameObject instigator,float damage)
        {
            
            if (health > 0)
            {
                health -= damage;
            }
            if(health <= 0)
            {
                health = 0;
                triggerDieAnimtion();
                AwardExperience(instigator);
                
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

        public JToken CaptureAsJToken()
        {
            return JToken.FromObject(health);
        }

        public void RestoreFromJToken(JToken state)
        {
            health = state.ToObject<float>();
            
        }



        public  float toPrecantage()
        {
            

            float prec = 100 * (health / GetComponent<BaseStats>().GetStat(Statis.Health));
            
            return prec;

        }


        private void AwardExperience(GameObject instigator)
        {
            Experience experience = instigator.GetComponent<Experience>();
            if (experience == null) return;

            experience.GainExperience(GetComponent<BaseStats>().GetStat(Statis.ExperienceReward));
        }

    }
}
