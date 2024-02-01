using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RPG.Attributes;


namespace RPG.Combat
{
    public class EnemyHealth : MonoBehaviour
    {
        Fighter fighter;
        Health health;



        private void Awake()
        {
            fighter = GameObject.FindWithTag("Player").GetComponent<Fighter>();
           
            
        }
        private void Update()
        {
           health=fighter.getTarget();

            if (health != null)
            {
                GetComponent<Text>().text = String.Format("{0:0}%", health.toPrecantage());
                return;
            }
            else
            {
                GetComponent<Text>().text = String.Format("None");
                return;

            }
        }


    }
}
