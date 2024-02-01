using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RPG.Attributes
{
    public class Experience : MonoBehaviour
    {
        [SerializeField] float experiencePoint = 0;
        public void GainExperience(float experience)
        {
            experiencePoint += experience;
        }
    }
}
