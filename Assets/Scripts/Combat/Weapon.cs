using RPG.Attributes;
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
        [SerializeField] Projectile projectile = null;
        const string weaponName = "Weapon";
       

       
        public void Spawn(Transform righthandtransform,Transform leftTransform, Animator animator)
        {
            DestroyOldWeapon(righthandtransform, leftTransform);
            if(weaponPrefab !=null )
            {
                Transform hand = GetHand(righthandtransform, leftTransform);
                GameObject weaponSpawn = Instantiate(weaponPrefab, hand);
                weaponSpawn.name = weaponName;
            }


            var overridecontroler = animator.runtimeAnimatorController as AnimatorOverrideController;

            if (animatorOverride != null)
            {
                animator.runtimeAnimatorController = animatorOverride;
            }
            else
            {
                 
                if (overridecontroler != null)
                {
                    animator.runtimeAnimatorController = overridecontroler.runtimeAnimatorController;
                }
            }
        }   

        private void DestroyOldWeapon(Transform righthandtransform, Transform leftTransform)
        {
            Transform oldWeapon =righthandtransform.Find(weaponName);
            if (oldWeapon == null) {
            
            oldWeapon =leftTransform.Find(weaponName);
            }
            if(oldWeapon == null) { return; }
            oldWeapon.name = "Destroy";
            Destroy(oldWeapon.gameObject);
        }

        public bool hasprojectile()
        {
            return projectile != null;
        }
        public void LunchProjectile(Transform  righthandtransform, Transform leftTransform,Health target)
        {
            Projectile projectileInstance = Instantiate(projectile, GetHand(righthandtransform, leftTransform).position, Quaternion.identity);
            projectileInstance.SetTarget(target,weaponDamage);
        }

       public float GetDamage(){return weaponDamage;}
       public float GetRangeOfAttack() { return RangeOfAttack; }

        public Transform GetHand(Transform righthandtransform, Transform leftTransform)
        {
            if (isRight) { return righthandtransform; }
            else
            {
                return leftTransform;

            }
        }


    }
}