using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPG.Attributes
{
    public class HealthDisplay : MonoBehaviour
    {
        Health health;



        private void Awake()
        {
            health = GameObject.FindWithTag("Player").GetComponent<Health>();
            print(health.toPrecantage());
            
        }
        private void Update()
        {
            GetComponent<Text>().text = String.Format("{0:0}%", health.toPrecantage());
        }


    }
}
