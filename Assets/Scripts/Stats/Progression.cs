using RPG.Stats;
using UnityEngine;
namespace RPG.Stats
{

    [CreateAssetMenu(fileName = "Progression", menuName = "Stats/New Progression", order = 0)]


    public class Progression : ScriptableObject
    {


        [SerializeField] ProgressionCharacterClass[] characterClasses = null;


        [System.Serializable]
         class ProgressionCharacterClass
        {
            public ClassCh characterClass;
            public float[] health;
        }

        public  float GetHealth(ClassCh classCh, int level)
        {
            foreach(ProgressionCharacterClass progression in characterClasses)
            {
                if(progression.characterClass == classCh)   
                {
                    return progression.health[level-1];
                }
            }
            return 0;

        }
    }
}