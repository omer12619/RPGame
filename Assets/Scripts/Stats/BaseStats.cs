using RPG.Attributes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 


namespace RPG.Stats
{
    public class BaseStats : MonoBehaviour
    {
        [Range(0f, 100f)]
        [SerializeField] int startingLevel;
        [SerializeField] ClassCh characterClass;

        [SerializeField] Progression progression;
        // Start is called before the first frame update
        public float GetStat(Statis stat)
        {
            return progression.GetStats(stat,characterClass, startingLevel);
        }
       
    }
};
