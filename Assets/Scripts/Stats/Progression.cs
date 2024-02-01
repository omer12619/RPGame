using RPG.Attributes;
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
            public Pograssionstats[] pograssionstats;
        }


        [System.Serializable]

        class Pograssionstats
        {
            public Statis stats;
            public float[] level;

        }

        public  float GetStats(Statis stat,ClassCh classCh ,int level)
        {
            foreach(ProgressionCharacterClass progression in characterClasses)
            {
                if (progression.characterClass != classCh) continue;  
                foreach( Pograssionstats pograssionstats in progression.pograssionstats)
                {
                    if (pograssionstats.stats != stat) continue;

                    if (pograssionstats.level.Length < level) continue;
                    return pograssionstats.level[level - 1];

                }
            }
            return 0;

        }
    }
}