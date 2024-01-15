using UnityEngine;

namespace RPG.Combat
{
    [CreateAssetMenu(fileName = "Weapon", menuName = "Weapons/Make New Weapon", order = 0)]
    public class Weapon : ScriptableObject
    {
        [SerializeField] AnimatorOverrideController animatorOverride = null;
        [SerializeField] GameObject weaponPrefab = null;
        [SerializeField] float weaponDamage = 1f;
        [SerializeField] float RangeOfAttack = 2f;
        [SerializeField] bool isRight = true;
       

       
        public void Spawn(Transform righthandtransform,Transform leftTransform, Animator animator)
        {
            if(weaponPrefab ==null || weaponPrefab == null) { return; }
            if (isRight) { Instantiate(weaponPrefab, righthandtransform); }
            else
            {
                Instantiate(weaponPrefab, leftTransform);

            }
            
            animator.runtimeAnimatorController = animatorOverride;
        }


       public float GetDamage(){return weaponDamage;}
        public float GetRangeOfAttack() { return RangeOfAttack; }


    }
}